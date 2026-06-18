using System;
using System.Collections.Generic;
using System.Linq;
using Npgsql;
using VendinhaTrabalho.Data;
using VendinhaTrabalho.Models;

namespace VendinhaTrabalho.Services
{
	public class DividaService
	{
		private readonly string _connectionString = ConexaoBanco.ConnectionString;

		
		private static DateTime ConverterParaDateTime(object valor)
		{
			if (valor is DateOnly data)
			{
				return data.ToDateTime(TimeOnly.MinValue);
			}
			return Convert.ToDateTime(valor);
		}

		public string AdicionarDivida(int idCliente, decimal valor)
		{
			bool temDividaAberta = false;
			string queryCheck = "SELECT EXISTS(SELECT 1 FROM divida WHERE idcliente = @idCliente AND situacao = false);";

			using (var conexao = new NpgsqlConnection(_connectionString))
			{
				try
				{
					conexao.Open();
					using (var cmdCheck = new NpgsqlCommand(queryCheck, conexao))
					{
						cmdCheck.Parameters.AddWithValue("@idCliente", idCliente);
						temDividaAberta = Convert.ToBoolean(cmdCheck.ExecuteScalar());
					}

					if (temDividaAberta)
					{
						return "Error: Cliente já tem uma divida em aberto!";
					}

					string queryProximoId = "SELECT COALESCE(MAX(iddivida), 0) + 1 FROM divida;";
					int novoIdDivida;

					using (var cmdProximoId = new NpgsqlCommand(queryProximoId, conexao))
					{
						novoIdDivida = Convert.ToInt32(cmdProximoId.ExecuteScalar());
					}

					string queryInsert = @"INSERT INTO divida (iddivida, valor, situacao datadecriacao, datapagamento, idcliente) VALUES (@iddivida, @valor, false, @datacriacao @datapagamento, @idCliente);";

					using (var cmdInsert = new NpgsqlCommand(queryInsert, conexao))
					{
						cmdInsert.Parameters.AddWithValue("@iddivida", novoIdDivida);
						cmdInsert.Parameters.AddWithValue("@valor", valor);
						cmdInsert.Parameters.AddWithValue("@datacriacao", DateTime.Today);
						cmdInsert.Parameters.AddWithValue("@datapagamento", (object)DBNull.Value);
						cmdInsert.Parameters.AddWithValue("@idCliente", idCliente);

						cmdInsert.ExecuteNonQuery();
					}
				}
				catch (Exception ex)
				{
					return "Error: Erro ao salvar no banco: " + ex.Message;
				}
			}

			return "Sucesso: Divida cadastrada.";
		}

		public decimal TotalDividaPorCpf(string cpf)
		{
			decimal total = 0;
			string query = @"SELECT COALESCE(SUM(d.valor), 0) FROM divida d INNER JOIN cliente c ON d.idcliente = c.idcliente WHERE c.cpf = @cpf AND d.situacao = false;";

			using (var conexao = new NpgsqlConnection(_connectionString))
			{
				try
				{
					conexao.Open();
					using (var comando = new NpgsqlCommand(query, conexao))
					{
						comando.Parameters.AddWithValue("@cpf", cpf);
						total = Convert.ToDecimal(comando.ExecuteScalar());
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("Erro ao somar dívida: " + ex.Message);
					throw; 
				}
			}
			return total;
		}

		public string DividaPaga(int idCliente)
		{
			using (var conexao = new NpgsqlConnection(_connectionString))
			{
				try
				{
					conexao.Open();

					
					int iddividaEmAberto = -1;

					string queryBuscar = @"SELECT iddivida FROM divida WHERE idcliente = @idCliente AND situacao = false ORDER BY iddivida ASC LIMIT 1;";

					using (var cmdBuscar = new NpgsqlCommand(queryBuscar, conexao))
					{
						cmdBuscar.Parameters.AddWithValue("@idCliente", idCliente);

						var resultado = cmdBuscar.ExecuteScalar();

						if (resultado == null || resultado == DBNull.Value)
						{
							return "Erro: Nenhuma dívida ativa foi encontrada para este cliente!";
						}

						iddividaEmAberto = Convert.ToInt32(resultado);
					}

					
					string queryAtualizar = @"UPDATE divida SET situacao = true, datapagamento = @datapagamento WHERE iddivida = @iddivida;";

					using (var cmdAtualizar = new NpgsqlCommand(queryAtualizar, conexao))
					{
						cmdAtualizar.Parameters.AddWithValue("@iddivida", iddividaEmAberto);
						cmdAtualizar.Parameters.AddWithValue("@datapagamento", DateTime.Today);

						cmdAtualizar.ExecuteNonQuery();
					}
				}
				catch (Exception ex)
				{
					return "Erro ao pagar dívida: " + ex.Message;
				}
			}

			return "Dívida paga com sucesso!";
		}
		public List<Dividas> ObterDividasPorCpf(int idCliente)
		{
		var lista = new List<Dividas>();

		string query = @"SELECT Valor, Situacao, DatadeCriacao, DataPagamento FROM divida WHERE idCliente = @idCliente ORDER BY iddivida DESC;";

		using (var conexao = new NpgsqlConnection(_connectionString))
		{
			try
			{
				conexao.Open();
				using (var comando = new NpgsqlCommand(query, conexao))
				{
					comando.Parameters.AddWithValue("@idCliente", idCliente);

					using (var reader = comando.ExecuteReader())
					{
						while (reader.Read())
						{
							var divida = new Dividas
							{
								Valor = Convert.ToDecimal(reader["Valor"]),
								Situacao = Convert.ToBoolean(reader["Situacao"]),
								DatadeCriacao = ConverterParaDateTime(reader["DatadeCriacao"]),
								DatadePagamento = Convert.ToBoolean(reader["Situacao"]) == false ? (DateTime?)null : ConverterParaDateTime(reader["DataPagamento"])
							};
							lista.Add(divida);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Erro ao buscar todas as dívidas: " + ex.Message);
			}
		}
		return lista;
		}
	}
}