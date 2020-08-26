using Base.Entity;
using DAL.Filtro;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Repositories
{
    public class RecebimentohubRepository : AbstractRepository<Recebimentohub, Int32>
    {
        public override void Delete(Recebimentohub entity)
        {
            using (var Minhaconexao = new SqlConnection(ConfigurationManager.ConnectionStrings["minhaconexao"].ConnectionString))
            {
                string delete = "DELETE TB_RECEBIMENTOHUB Where Id_Recebimento=@Id";
                SqlCommand cmd = new SqlCommand(delete, Minhaconexao);
                cmd.Parameters.AddWithValue("@Id", entity.Id);
                try
                {
                    Minhaconexao.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public override void DeleteById(int id)
        {
            using (var Minhaconexao = new SqlConnection(ConfigurationManager.ConnectionStrings["minhaconexao"].ConnectionString))
            {
                string del = "DELETE TB_RECEBIMENTOHUB Where Id_Recebimento=@Id";
                SqlCommand cmd = new SqlCommand(del, Minhaconexao);
                cmd.Parameters.AddWithValue("@Id", id);
                try
                {
                    Minhaconexao.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;  // new Exception("Erro ao carregar dados do registro do Aniel: " + e.Message);
                }

            }
        }

        public List<Recebimentohub> GetAll(FiltroRecebimentoHub filtro)
        {
            using (var Minhaconexao = new SqlConnection(ConfigurationManager.ConnectionStrings["minhaconexao"].ConnectionString))
            {
                //string select = "Select Id_Recebimento,DataRecebimento,HoraRecebimento,Cliente,HoraIni,HoraFim,QuantidadeEncomendas,TipoEmbalagem,PlacaCaminhão FROM TB_RECEBIMENTOHUB ORDER BY Id_Recebimento";
                StringBuilder SQL = new StringBuilder();
                SQL.Append("Select ");
                SQL.Append("Id_Recebimento,  ");
                SQL.Append("DataRecebimento, ");
                SQL.Append("HoraRecebimento, ");
                SQL.Append("Cliente, ");
                SQL.Append("HoraIni, ");
                SQL.Append("HoraFim, ");
                SQL.Append("QuantidadeEncomendas, ");
                SQL.Append("TipoEmbalagem, ");
                SQL.Append("PlacaCaminhão ");
                SQL.Append("FROM TB_RECEBIMENTOHUB where 1 = 1 ");

                if (filtro.Id != 0)
                {
                    SQL.Append(" and ID = " + filtro.Id);
                }

                if (filtro.Cliente != null)
                {
                    SQL.Append(" and cliente like '% " + filtro.Id + "%' ");
                }

                SQL.Append("ORDER BY Id_Recebimento ");

                var cmd = new SqlCommand(SQL.ToString(), Minhaconexao); ;
                List<Recebimentohub> list = new List<Recebimentohub>();
                
                try
                {
                    Minhaconexao.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            Recebimentohub p = new Recebimentohub();
                            p.Id = (int)reader["Id_Recebimento"];
                            p.DataRecebimento = reader["DataRecebimento"].ToString();
                            p.HoraRecebimento = reader["HoraRecebimento"].ToString();
                            p.Cliente = reader["Cliente"].ToString();
                            p.Hora_Inicial = reader["HoraIni"].ToString();
                            p.Hora_Final = reader["HoraFim"].ToString();
                            p.Volume = reader["QuantidadeEncomendas"].ToString();
                            p.TipoEmbalagem = reader["TipoEmbalagem"].ToString();
                            p.Placa = reader["PlacaCaminhão"].ToString();
                            list.Add(p);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return list;
            }
        }

        public override List<Recebimentohub> GetAll(Recebimentohub entity)
        {
            throw new NotImplementedException();
        }

        public override Recebimentohub GetById(int id)
        {
            using (var Minhaconexao = new SqlConnection(ConfigurationManager.ConnectionStrings["minhaconexao"].ConnectionString))
            {
                string sql = "Select Id_Recebimento,DataRecebimento,HoraRecebimento,Cliente,HoraIni,HoraFim,QuantidadeEncomendas,TipoEmbalagem,PlacaCaminhão FROM TB_RECEBIMENTOHUB WHERE Id_Recebimento=@Id";
                SqlCommand cmd = new SqlCommand(sql, Minhaconexao);
                cmd.Parameters.AddWithValue("@Id", id);
                Recebimentohub p = null;
                try
                {
                    Minhaconexao.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                p = new Recebimentohub();
                                p.Id = (int)reader["Id_Recebimento"];
                                p.DataRecebimento = reader["DataRecebimento"].ToString();
                                p.HoraRecebimento = reader["HoraRecebimento"].ToString();
                                p.Cliente = reader["Cliente"].ToString();
                                p.Hora_Inicial = reader["HoraIni"].ToString();
                                p.Hora_Final = reader["HoraFim"].ToString();
                                p.Volume = reader["QuantidadeEncomendas"].ToString();
                                p.TipoEmbalagem = reader["TipoEmbalagem"].ToString();
                                p.Placa = reader["PlacaCaminhão"].ToString();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return p;
            }
        }

        public override void Save(Recebimentohub entity)
        {
            SqlConnection MinhaConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["minhaconexao"].ConnectionString);

            MinhaConexao.Open();



            string insert = "INSERT INTO TB_RECEBIMENTOHUB (DataRecebimento, HoraRecebimento, Cliente,HoraIni,HoraFim,QuantidadeEncomendas,TipoEmbalagem,PlacaCaminhão) VALUES (@DataRecebimento, @HoraRecebimento, @Cliente, @HoraIni,@HoraFim,@QuantidadeEncomendas,@TipoEmbalagem,@PlacaCaminhão)";
            SqlCommand cmd = new SqlCommand(insert, MinhaConexao);
            cmd.Parameters.AddWithValue("@DataRecebimento", entity.DataRecebimento);
            cmd.Parameters.AddWithValue("@HoraRecebimento", entity.HoraRecebimento);
            cmd.Parameters.AddWithValue("@Cliente", entity.Cliente);
            cmd.Parameters.AddWithValue("@HoraIni", entity.Hora_Inicial);
            cmd.Parameters.AddWithValue("@HoraFim", entity.Hora_Final);
            cmd.Parameters.AddWithValue("@QuantidadeEncomendas", entity.Volume);
            cmd.Parameters.AddWithValue("@TipoEmbalagem", entity.TipoEmbalagem);
            cmd.Parameters.AddWithValue("@PlacaCaminhão", entity.Placa);

            cmd.ExecuteNonQuery();
            MinhaConexao.Close();

        }

        public override void Update(Recebimentohub entity)
        {
            SqlConnection MinhaConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["minhaconexao"].ConnectionString);

            MinhaConexao.Open();



            string update = "UPDATE TB_RECEBIMENTOHUB SET DataRecebimento=@DataRecebimento,HoraRecebimento=@HoraRecebimento, Cliente=@Cliente, HoraIni=@HoraIni, HoraFim=@HoraFim,QuantidadeEncomendas=@QuantidadeEncomendas,TipoEmbalagem=@TipoEmbalagem,PlacaCaminhão=@PlacaCaminhão  Where Id_Recebimento=@Id";
            SqlCommand cmd = new SqlCommand(update, MinhaConexao);
            cmd.Parameters.AddWithValue("@Id", entity.Id);
            cmd.Parameters.AddWithValue("@DataRecebimento", entity.DataRecebimento);
            cmd.Parameters.AddWithValue("@HoraRecebimento", entity.HoraRecebimento);
            cmd.Parameters.AddWithValue("@Cliente", entity.Cliente);
            cmd.Parameters.AddWithValue("@HoraIni", entity.Hora_Inicial);
            cmd.Parameters.AddWithValue("@HoraFim", entity.Hora_Final);
            cmd.Parameters.AddWithValue("@QuantidadeEncomendas", entity.Volume);
            cmd.Parameters.AddWithValue("@TipoEmbalagem", entity.TipoEmbalagem);
            cmd.Parameters.AddWithValue("@PlacaCaminhão", entity.Placa);
            cmd.ExecuteNonQuery();
            MinhaConexao.Close();


        }

    }
}
