using Cadastro_Pessoa_FS1.Interfaces;

namespace Cadastro_Pessoa_FS1.Classes
{
  public class PessoaFisica : Pessoa, IPessoaFisica
  {

    public string? cpf { get; set; }
    public string? dataNascimento { get; set; }



    public bool ValidarDataNascimento(DateTime dateNasc)
    {
      DateTime dataAtual = DateTime.Today;

      double anos = (dataAtual - dateNasc).TotalDays / 365;

      if (anos >= 18)
      {
        return true;
      }
      return false;


    }




    public override float PagarImposto(float rendimento)
    {
      throw new NotImplementedException();
    }

    internal object ValidarDataNascimento(string dataNascimento)
    {
      throw new NotImplementedException();
    }
  }
}