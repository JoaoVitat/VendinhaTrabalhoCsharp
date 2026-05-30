using System;
using System.Collections.Generic;
using System.Linq;
using Npgsql;
using VendinhaTrabalho.Models;

namespace VendinhaTrabalho.Services
{
	public class DividaService
	{
		private readonly string _connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=3451;Database=db_vendinha;";

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

					string queryInsert = @"INSERT INTO divida (iddivida, valor, situacao, datadecriacao, datapagamento, idcliente) 
                                          VALUES ((SELECT COALESCE(MAX(iddivida), 0) + 1 FROM divida), @valor, false, @datacriacao, @datapagamento, @idCliente);";

					using (var cmdInsert = new NpgsqlCommand(queryInsert, conexao))
					{
						cmdInsert.Parameters.AddWithValue("@valor", valor);
						cmdInsert.Parameters.AddWithValue("@datacriacao", DateTime.Today);
						cmdInsert.Parameters.AddWithValue("@datapagamento", DateTime.Today);
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
			string query = @"SELECT COALESCE(SUM(d.valor), 0) 
                             FROM divida d
                             INNER JOIN cliente c ON d.idcliente = c.idcliente
                             WHERE c.cpf = @cpf AND d.situacao = false;";

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
				}
			}
			return total;
		}

		public string DividaPaga(int idCliente)
		{
			string queryUpdate = @"UPDATE divida 
                                  SET situacao = true, datapagamento = @datapagamento 
                                  WHERE iddivida = (
                                      SELECT iddivida FROM divida 
                                      WHERE idcliente = @idCliente AND situacao = false 
                                      ORDER BY iddivida ASC LIMIT 1
                                  );";

			using (var conexao = new NpgsqlConnection(_connectionString))
			{
				try
				{
					conexao.Open();
					using (var comando = new NpgsqlCommand(queryUpdate, conexao))
					{
						comando.Parameters.AddWithValue("@idCliente", idCliente);
						comando.Parameters.AddWithValue("@datapagamento", DateTime.Today);

						int linhasAfetadas = comando.ExecuteNonQuery();

						if (linhasAfetadas == 0)
						{
							return $"Erro: Nenhuma divida ativa foi encontrada para este cliente!";
						}
					}
				}
				catch (Exception ex)
				{
					return "Erro ao pagar dívida no banco: " + ex.Message;
				}
			}

			return $"Divida paga com sucesso!";
		}
		public List<Dividas> ObterDividasPorCpf(int idCliente)
		{
		var lista = new List<Dividas>();

		string query = @"SELECT Valor, Situacao, DatadeCriacao, DataPagamento 
                    FROM divida 
                    WHERE idCliente = @idCliente
                    ORDER BY iddivida DESC;";

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
								DatadeCriacao = Convert.ToDateTime(reader["DatadeCriacao"]),
								DatadePagamento = Convert.ToBoolean(reader["Situacao"]) == false ? (DateTime?)null : Convert.ToDateTime(reader["DataPagamento"])
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