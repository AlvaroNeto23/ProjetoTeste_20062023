using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Número Por Extenso

        protected void btnNumExtenso_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNumInteiro.Value))
                {
                    ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert", "<script language='javascript'> { window.alert(\" Preencha o campo com um 'Número Inteiro de até 4 caracteres'. \") }</script>");
                    return;
                }

                int num = Convert.ToInt32(txtNumInteiro.Value);

                txtResultado.Value = funcao_retornaExtenso(num);
            }
            catch (Exception ex)
            {
                txtResultado.Value = "Gerou uma exceção. Erro: " + ex.Message;
                throw;
            }
        }

        private string funcao_retornaExtenso(int intNum)
        {
            try
            {
                string strNum = string.Empty;
                string strMilhar = string.Empty;
                string strCentena = string.Empty;
                string strDezena = string.Empty;
                string strUnidade = string.Empty;
                string strExtenso = string.Empty;

                strNum = intNum.ToString();
                strNum = strNum.PadLeft(4, '0');

                string zero = "0000";

                if (strNum == zero)
                    return "Zero";

                if (strNum[0] != '0')
                {
                    switch (strNum[0])
                    {
                        case '1': strMilhar = "Um Mil"; break;
                        case '2': strMilhar = "Dois Mil"; break;
                        case '3': strMilhar = "Três Mil"; break;
                        case '4': strMilhar = "Quatro Mil"; break;
                        case '5': strMilhar = "Cinco Mil"; break;
                        case '6': strMilhar = "Seis Mil"; break;
                        case '7': strMilhar = "Sete Mil"; break;
                        case '8': strMilhar = "Oito Mil"; break;
                        case '9': strMilhar = "Nove Mil"; break;
                    }
                }

                if (strNum[1] != '0')
                {
                    switch (strNum[1])
                    {
                        case '1': strCentena = "Cento "; break;
                        case '2': strCentena = "Duzentos "; break;
                        case '3': strCentena = "Trezentos "; break;
                        case '4': strCentena = "Quatrocentos "; break;
                        case '5': strCentena = "Quinhentos "; break;
                        case '6': strCentena = "Seiscentos "; break;
                        case '7': strCentena = "Setecentos "; break;
                        case '8': strCentena = "Oitocentos "; break;
                        case '9': strCentena = "Novecentos "; break;

                    }
                    if (strNum[1] == '1' && strNum[2] == '0' && strNum[3] == '0')
                        strCentena = "Cem";
                }

                if (strNum[2] == '1')
                {
                    switch (strNum.Substring(2))
                    {
                        case "10": strDezena = "e Dez"; break;
                        case "11": strDezena = "e Onze"; break;
                        case "12": strDezena = "e Doze"; break;
                        case "13": strDezena = "e Treze"; break;
                        case "14": strDezena = "e Quatorze"; break;
                        case "15": strDezena = "e Quinze"; break;
                        case "16": strDezena = "e Dezesseis"; break;
                        case "17": strDezena = "e Dezessete"; break;
                        case "18": strDezena = "e Dezoito"; break;
                        case "19": strDezena = "e Dezenove"; break;
                    }
                }
                else if (strNum[2] != '0')
                {
                    switch (strNum[2])
                    {
                        case '2': strDezena = "e Vinte "; break;
                        case '3': strDezena = "e Trinta "; break;
                        case '4': strDezena = "e Quarenta "; break;
                        case '5': strDezena = "e Cinquenta "; break;
                        case '6': strDezena = "e Secenta "; break;
                        case '7': strDezena = "e Setenta "; break;
                        case '8': strDezena = "e Oitenta "; break;
                        case '9': strDezena = "e Noventa "; break;
                    }
                }

                if (strNum[3] != '0' && strNum[2] != '1')
                {
                    switch (strNum[3])
                    {
                        case '1': strUnidade = "e Um"; break;
                        case '2': strUnidade = "e Doiz"; break;
                        case '3': strUnidade = "e Três"; break;
                        case '4': strUnidade = "e Quatro"; break;
                        case '5': strUnidade = "e Cinco"; break;
                        case '6': strUnidade = "e Seis"; break;
                        case '7': strUnidade = "e Sete"; break;
                        case '8': strUnidade = "e Oito"; break;
                        case '9': strUnidade = "e Nove"; break;
                    }
                }

                //Preenchendo o extenso
                strExtenso = strMilhar + strCentena + strDezena + strUnidade;

                if (strExtenso[0] == 'e')
                    strExtenso = strExtenso.Substring(2);

                return strExtenso;
            }
            catch (Exception ex)
            {
                return "Gerou uma exceção. Erro: " + ex.Message;
                throw;
            }
        }

        #endregion

        #region Expressão Matemática

        protected void btnExprMatem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtExprMatem.Value))
                {
                    ClientScript.RegisterStartupScript(System.Type.GetType("System.String"), "Alert", "<script language='javascript'> { window.alert(\" Preencha o campo 'Expressão Matemática'. \") }</script>");
                    return;
                }

                txtResultadoExprMatem.Value = funcao_ExpressaoMatematica(txtExprMatem.Value);
            }
            catch (Exception ex)
            {
                txtResultado.Value = "Gerou uma exceção. Erro: " + ex.Message;
                throw;
            }
        }

        private string funcao_ExpressaoMatematica(string strExpressao)
        {
            try
            {
                strExpressao = strExpressao.Replace(" ", "");
                

                string numeros = String.Join("", System.Text.RegularExpressions.Regex.Split(strExpressao, @"[^\d]"));
                string sinais = String.Join("", System.Text.RegularExpressions.Regex.Split(strExpressao, @"[\d]"));

                for (int i=0; i<numeros.Length; i++)
                {

                }

                return "";
            }
            catch (Exception ex)
            {
                return "Gerou uma exceção. Erro: " + ex.Message;
                throw;
            }
        }

        #endregion
    }
}