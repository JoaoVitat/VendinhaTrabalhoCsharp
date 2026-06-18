using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using Npgsql;
using VendinhaTrabalho.Data;
using VendinhaTrabalho.Models;
using VendinhaTrabalho.Services;

namespace VendinhaTrabalho
{
	public class ClienteServices
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

		public bool AdicionarCliente(Clientes cliente, out string erro)
		{
			if (!ValidarCliente(cliente, out erro))
			{
				return false;
			}

			if (CpfJaCadastrado(cliente.Cpf))
			{
				erro = "Este CPF já está cadastrado!";
				return false;
			}

			int novoId = ObterProximoIdCliente();

			string query = @"INSERT INTO cliente (idcliente, nome, cpf, datanascimento, email) VALUES (@idcliente, @nome, @cpf, @datanascimento, @email);";

			using (var conexao = new NpgsqlConnection(_connectionString))
			{
				try
				{
					conexao.Open();

					using (var comando = new NpgsqlCommand(query, conexao))
					{
						comando.Parameters.AddWithValue("@idcliente", novoId);
						comando.Parameters.AddWithValue("@nome", cliente.Nome);
						comando.Parameters.AddWithValue("@cpf", cliente.Cpf);
						comando.Parameters.AddWithValue("@datanascimento", cliente.DataNascimento);
						comando.Parameters.AddWithValue("@email", cliente.Email ?? (object)DBNull.Value);

						comando.ExecuteNonQuery();
						cliente.IdCliente = novoId;
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


		private int ObterProximoIdCliente()
		{
			string query = "SELECT COALESCE(MAX(idcliente), 0) + 1 FROM cliente;";

			using (var conexao = new NpgsqlConnection(_connectionString))
			{
				conexao.Open();

				using (var comando = new NpgsqlCommand(query, conexao))
				{
					return Convert.ToInt32(comando.ExecuteScalar());
				}
			}
		}

		private bool ValidarCliente(Clientes cliente, out string erro)
		{
			erro = null;

			var contexto = new ValidationContext(cliente);
			var resultados = new List<ValidationResult>();

			bool valido = Validator.TryValidateObject(cliente, contexto, resultados, validateAllProperties: true);

			if (!valido)
			{
				erro = resultados.First().ErrorMessage;
				return false;
			}

			if (!Regex.IsMatch(cliente.Cpf, @"^\d{11}$"))
			{
				erro = "CPF inválido! Digite apenas 11 números.";
				return false;
			}

			if (!Regex.IsMatch(cliente.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
			{
				erro = "Email inválido!";
				return false;
			}

			return true;
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
									DataNascimento = ConverterParaDateTime(reader["datanascimento"]),
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
					throw; 
				}
			}

			return lista;
		}

		public bool AtualizarCliente(Clientes atualizarCliente, out string erro)
		{
			if (!ValidarCliente(atualizarCliente, out erro))
			{
				return false;
			}

			string query = @"UPDATE cliente SET nome = @nome, cpf = @cpf, datanascimento = @datanascimento, email = @email WHERE idcliente = @idcliente;";

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
	}
}