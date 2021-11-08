namespace DataAccess
{
    using DataAccess.Contract;
    using DataAccess.Repository;
    using Entity_Layer;
    using Oracle.DataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class daoCliente : OracleConexion, IOperacionesCrud<ClienteBO>
    {
        public string Actualizar(ClienteBO dto)
        {
            string resultado = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(srtOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_UPDATE_CLIENTE", cn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_DNI", OracleDbType.Varchar2)).Value = dto.DNI;
                        command.Parameters.Add(new OracleParameter("P_NOMBRE", OracleDbType.Varchar2)).Value = dto.NOMBRE;
                        command.Parameters.Add(new OracleParameter("P_APELLIDO", OracleDbType.Varchar2)).Value = dto.APELLIDO;
                        command.Parameters.Add(new OracleParameter("P_EMAIL", OracleDbType.Varchar2)).Value = dto.EMAIL;
                        command.Parameters.Add(new OracleParameter("P_TELEFONO", OracleDbType.Int32)).Value = dto.TELEFONO;
                        command.Parameters.Add(new OracleParameter("P_RESULT", OracleDbType.Varchar2, 50)).Direction = ParameterDirection.Output;
                        command.ExecuteNonQuery();
                        resultado = Convert.ToString(command.Parameters["P_RESULT"].Value);
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                new Exception("Error al insertar un cliente." + ex.Message.ToString());
            }
            return resultado;
        }

        public string Eliminar(string dto)
        {
            string resultado = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(srtOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_DELETE_CLIENTE", cn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_DNI", OracleDbType.Varchar2)).Value = dto;
                        command.Parameters.Add(new OracleParameter("P_RESULT", OracleDbType.Varchar2, 50)).Direction = ParameterDirection.Output;
                        command.ExecuteNonQuery();
                        resultado = Convert.ToString(command.Parameters["P_RESULT"].Value);
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                new Exception("Error al insertar un cliente." + ex.Message.ToString());
            }
            return resultado;
        }

        public string Insertar(ClienteBO dto)
        {
            string resultado = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(srtOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_INSERT_CLIENTE", cn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_DNI", OracleDbType.Varchar2)).Value = dto.DNI;
                        command.Parameters.Add(new OracleParameter("P_NOMBRE", OracleDbType.Varchar2)).Value = dto.NOMBRE;
                        command.Parameters.Add(new OracleParameter("P_APELLIDO", OracleDbType.Varchar2)).Value = dto.APELLIDO;
                        command.Parameters.Add(new OracleParameter("P_EMAIL", OracleDbType.Varchar2)).Value = dto.EMAIL;
                        command.Parameters.Add(new OracleParameter("P_TELEFONO", OracleDbType.Int32)).Value = dto.TELEFONO;
                        command.Parameters.Add(new OracleParameter("P_RESULT", OracleDbType.Varchar2, 50)).Direction = ParameterDirection.Output;
                        command.ExecuteNonQuery();
                        resultado = Convert.ToString(command.Parameters["P_RESULT"].Value);
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                new Exception("Error al insertar un cliente." + ex.Message.ToString());
            }
            return resultado;
        }

        public List<ClienteBO> Listar()
        {
            List<ClienteBO> listClientes = new List<ClienteBO>();
            ClienteBO objeto;
            try
            {
                using (OracleConnection cn = new OracleConnection(srtOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_SELECT_CLIENTE", cn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;

                        using (OracleDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (dr.Read())
                            {
                                objeto = new ClienteBO();
                                objeto.DNI = Convert.ToString(dr["DNI"]);
                                objeto.NOMBRE = Convert.ToString( dr["NOMBRE"]);
                                objeto.APELLIDO = Convert.ToString(dr["APELLIDO"]);
                                objeto.EMAIL = Convert.ToString(dr["EMAIL"]);
                                objeto.TELEFONO = Convert.ToString(dr["TELEFONO"]);
                                listClientes.Add(objeto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception("Error en el metodo" + ex.Message.ToString());
            }

            return listClientes;
        }
    }
}