﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FI.AtividadeEntrevista.DML;

namespace FI.AtividadeEntrevista.DAL
{

    /// <summary>
    /// Classe de acesso a dados de Beneficiario
    /// </summary>
    internal class DaoBeneficiario : AcessoDados
    {
        /// <summary>
        /// Inclui um novo beneficiario
        /// </summary>
        /// <param name="beneficiario">Objeto de cliente</param>
        internal long Incluir(DML.Beneficiario beneficiario)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("Nome", beneficiario.Nome));
            parametros.Add(new System.Data.SqlClient.SqlParameter("CPF", BLL.Formatacao.SemFormatacao(beneficiario.CPF)));
            parametros.Add(new System.Data.SqlClient.SqlParameter("IdCliente", beneficiario.IdCliente));

            DataSet ds = base.Consultar("FI_SP_IncBeneficiario", parametros);
            long ret = 0;
            if (ds.Tables[0].Rows.Count > 0)
                long.TryParse(ds.Tables[0].Rows[0][0].ToString(), out ret);
            return ret;
        }

        internal bool VerificarExistencia(long idClient, string CPF)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("IdClient", idClient));
            parametros.Add(new System.Data.SqlClient.SqlParameter("CPF", CPF));

            DataSet ds = base.Consultar("FI_SP_VerificaBeneficiario", parametros);

            return ds.Tables[0].Rows.Count > 0;
        }

        /// <summary>
        /// Inclui um novo cliente
        /// </summary>
        /// <param name="beneficiario">Objeto de cliente</param>
        internal void Alterar(DML.Beneficiario beneficiario)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("Nome", beneficiario.Nome));
            parametros.Add(new System.Data.SqlClient.SqlParameter("CPF", beneficiario.CPF));
            parametros.Add(new System.Data.SqlClient.SqlParameter("ID", beneficiario.Id));

            base.Executar("FI_SP_AltBeneficiario", parametros);
        }

        /// <summary>
        /// Excluir Cliente
        /// </summary>
        /// <param name="beneficiario">Objeto de cliente</param>
        internal void Excluir(long Id)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("ID", Id));

            base.Executar("FI_SP_DelBeneficiario", parametros);
        }

        /// <summary>
        /// Consulta beneficiario pelo id
        /// </summary>
        /// <param name="id">id de beneficiario</param>
        internal DML.Beneficiario Consultar(long Id)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("Id", Id));

            DataSet ds = base.Consultar("FI_SP_ConsBeneficiario", parametros);
            List<DML.Beneficiario> beneficiario = Converter(ds);

            return beneficiario.FirstOrDefault();
        }

        /// <summary>
        /// Lista todos os clientes
        /// </summary>
        internal List<DML.Beneficiario> Listar()
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("Id", 0));

            DataSet ds = base.Consultar("FI_SP_ConsBeneficiario", parametros);
            List<DML.Beneficiario> beneficiarios = Converter(ds);

            return beneficiarios;
        }

        private List<DML.Beneficiario> Converter(DataSet ds)
        {
            List<DML.Beneficiario> lista = new List<DML.Beneficiario>();
            if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DML.Beneficiario beneficiario = new DML.Beneficiario();
                    beneficiario.Id = row.Field<long>("Id");
                    beneficiario.Nome = row.Field<string>("Nome");
                    beneficiario.CPF = BLL.Formatacao.FormataCPF(row.Field<string>("CPF"));
                    lista.Add(beneficiario);
                }
            }
            return lista;
        }
    }
}
