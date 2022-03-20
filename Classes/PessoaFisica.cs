using Cadastro_Pessoa_FS1.Interfaces;

namespace Cadastro_Pessoa_FS1.Classes
{
  public class PessoaFisica : Pessoa, IPessoaFisica
  {
    private DateTime dateNasc;

    public string? cpf { get; set; }
    public string? dataNascimento { get; set; }



    public bool ValidarDataNascimento(DateTime dateNasc)
    {
      DateTime dataAtual = DateTime.Today;

      double anos = (dataAtual - dateNasc).TotalDays / 365;

      if (anos >= 18 && anos < 120)
      {
        return true;
      }
      return true;


    }




    public override float PagarImposto(float rendimento)
    {
      if (rendimento <= 1500)
      {
        return 0;
      }
      else if (rendimento > 1500 && rendimento <= 3500)
      {
        return (rendimento / 100) * 2;
      }
      else if (rendimento > 3500 && rendimento < 6000)
      {
        return (rendimento / 100) * 3.5f;
      }
      else
      {
        return (rendimento / 100) * 5;
      }
    }

    internal bool ValidarDataNascimento(string dataNascimento)
    {
      DateTime dataAtual = DateTime.Today;

      double anos = (dataAtual - dateNasc).TotalDays / 365;

      if (anos >= 18 && anos < 120)
      {
        return true;
      }
      return true;
    }
  }
}