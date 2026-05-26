using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Npgsql;
using VendinhaTrabalho.Models;
using VendinhaTrabalho.Services;

namespace VendinhaTrabalho
{
	public class ClienteServices
	{
		private readonly string _connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=3451;Database=db_vendinha;";

		public bool AdicionarCliente(Clientes cliente, out string erro)
		{
			erro = null;

			if (CpfJaCadastrado(cliente.Cpf))
			{
				erro = "Este CPF já está cadastrado!";
				return false;
			}

			string query = @"INSERT INTO cliente (nome, cpf, datanascimento, email) 
                             VALUES (@nome, @cpf, @datanascimento, @email);";

			using (var conexao = new NpgsqlConnection(_connectionString))
			{
				try
				{
					conexao.Open();
					using (var comando = new NpgsqlCommand(query, conexao))
					{
						comando.Parameters.AddWithValue("@nome", cliente.Nome);
						comando.Parameters.AddWithValue("@cpf", cliente.Cpf);
						comando.Parameters.AddWithValue("@datanascimento", cliente.DataNascimento);
						comando.Parameters.AddWithValue("@email", cliente.Email ?? (object)DBNull.Value);

						comando.ExecuteNonQuery();
						return true;
					}
				}
				catch (Exception ex)
				{
					erro = "Erro ao salvar no banco: " + ex.Message;
					return false;
				}
			}
		}

		public List<Clientes> ObterTodos()
		{
			var lista = new List<Clientes>();
			string query = "SELECT idcliente, nome, cpf, datanascimento, email FROM cliente ORDER BY idcliente ASC;";

			using (var conexao = new NpgsqlConnection(_connectionString))
			{
				try
				{
					conexao.Open();
					using (var comando = new NpgsqlCommand(query, conexao))
					{
						using (var reader = comando.ExecuteReader())
						{
							while (reader.Read())
							{
								var cliente = new Clientes
								{
									IdCliente = Convert.ToInt32(reader["idcliente"]),
									Nome = reader["nome"].ToString(),
									Cpf = reader["cpf"].ToString(),
									DataNascimento = Convert.ToDateTime(reader["datanascimento"]),
									Email = reader["email"].ToString()
								};
								lista.Add(cliente);
							}
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("Erro ao buscar clientes: " + ex.Message);
				}
			}
			return lista;
		}

		public bool AtualizarCliente(Clientes atualizarCliente, out string erro)
		{
			erro = null;

			string query = @"UPDATE cliente 
                             SET nome = @nome, cpf = @cpf, datanascimento = @datanascimento, email = @email 
                             WHERE idcliente = @idcliente;";

			using (var conexao = new NpgsqlConnection(_connectionString))
			{
				try
				{
					conexao.Open();
					using (var comando = new NpgsqlCommand(query, conexao))
					{
						comando.Parameters.AddWithValue("@idcliente", atualizarCliente.IdCliente);
						comando.Parameters.AddWithValue("@nome", atualizarCliente.Nome);
						comando.Parameters.AddWithValue("@cpf", atualizarCliente.Cpf);
						comando.Parameters.AddWithValue("@datanascimento", atualizarCliente.DataNascimento);
						comando.Parameters.AddWithValue("@email", atualizarCliente.Email ?? (object)DBNull.Value);

						comando.ExecuteNonQuery();
						return true;
					}
				}
				catch (Exception ex)
				{
					erro = "Erro ao atualizar: " + ex.Message;
					return false;
				}
			}
		}

		public bool RemoverCliente(int idCliente)
		{
			string query = "DELETE FROM cliente WHERE idcliente = @idcliente;";

			using (var conexao = new NpgsqlConnection(_connectionString))
			{
				try
				{
					conexao.Open();
					using (var comando = new NpgsqlCommand(query, conexao))
					{
						comando.Parameters.AddWithValue("@idcliente", idCliente);
						comando.ExecuteNonQuery();
						return true;
					}
				}
				catch
				{
					return false;
				}
			}
		}

		private bool CpfJaCadastrado(string cpf)
		{
			string query = "SELECT COUNT(*) FROM cliente WHERE cpf = @cpf;";
			using (var conexao = new NpgsqlConnection(_connectionString))
			{
				conexao.Open();
				using (var comando = new NpgsqlCommand(query, conexao))
				{
					comando.Parameters.AddWithValue("@cpf", cpf);
					long contagem = (long)comando.ExecuteScalar();
					return contagem > 0;
				}
			}
		}

		public Clientes RecuperarCliente(string cpfPesquisa)
		{
			return ObterTodos().FirstOrDefault(c => c.Cpf.Trim() == cpfPesquisa.Trim());
		}

		public Clientes ObterPorId(int id)
		{
			return ObterTodos().FirstOrDefault(c => c.IdCliente == id);
		}

		public List<Clientes> OrdenadosPorDivida(DividaService dividaService)
		{
			return ObterTodos()
			.OrderByDescending(cliente => dividaService.TotalDividaPorCpf(cliente.Cpf))
			.ToList();
		}

		public List<Clientes> ObterPorPagina(int paginaAtual)
		{
			var lista = new List<Clientes>();
			int tamanhoPagina = 10;

			if (paginaAtual < 1) paginaAtual = 1;
			int registrosParaPular = (paginaAtual - 1) * tamanhoPagina;

			string query = @"SELECT idcliente, nome, cpf, datanascimento, email 
                     FROM cliente 
                     ORDER BY idcliente ASC 
                     LIMIT @limit OFFSET @offset;";

			using (var conexao = new NpgsqlConnection(_connectionString))
			{
				try
				{
					conexao.Open();
					using (var comando = new NpgsqlCommand(query, conexao))
					{
						comando.Parameters.Add("@limit", NpgsqlTypes.NpgsqlDbType.Integer).Value = tamanhoPagina;
						comando.Parameters.Add("@offset", NpgsqlTypes.NpgsqlDbType.Integer).Value = registrosParaPular;

						using (var reader = comando.ExecuteReader())
						{
							while (reader.Read())
							{
								var cliente = new Clientes
								{
									IdCliente = Convert.ToInt32(reader["idcliente"]),
									Nome = reader["nome"].ToString(),
									Cpf = reader["cpf"].ToString(),
									DataNascimento = Convert.ToDateTime(reader["datanascimento"]),
									Email = reader["email"].ToString()
								};
								lista.Add(cliente);
							}
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("Erro: " + ex.Message);
				}
			}
			return lista;
		}
	}
}