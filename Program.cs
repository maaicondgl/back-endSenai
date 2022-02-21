// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Cadastro_Pessoa_FS1.Classes;

Console.WriteLine(@$"
==================================================
| Bem vindo ao Sistema de cadastro de            | 
|      Pessoa Fisicas e Juridicas                 |
================================================== 
");
Console.BackgroundColor = ConsoleColor.DarkBlue;
Console.ForegroundColor = ConsoleColor.Black;
Console.Write("Carregando ");

for (var contador = 0; contador < 10; contador++)
{
  Console.Write(". ");
  Thread.Sleep(500);
}
Console.ResetColor();

string? opcao;

do
{
  Console.WriteLine(@$"
 =======================================================
 |           Escolha uma das opçoes abaixo              |
 |           1 - Pessoa Fisica                          |
 |           2 - Pessoa Juridíca                        |
 |                                                      |
 |            0 - Sair                                  |
 |                                                      |
 =======================================================
 ");

  opcao = Console.ReadLine();
  Console.Clear();

  switch (opcao)
  {
    case "1":
      PessoaFisica metodoPf = new PessoaFisica();

      PessoaFisica novaPf = new PessoaFisica();
      Endereco novoEnd = new Endereco();
      novaPf.nome = "MaiconDouglas";
      novaPf.dataNascimento = "01/01/200";
      novaPf.cpf = "1234567890";
      novaPf.rendimento = 15000.5f;

      novoEnd.longradouro = "Alameda Barão de Limeira";
      novoEnd.numero = 539;
      novoEnd.complemento = "SENAI Informatica";
      novoEnd.endComercial = true;

      novaPf.endereco = novoEnd;

      Console.WriteLine(@$"
       Nome: {novaPf.nome}
       Endereço: {novaPf.endereco.longradouro}, {novaPf.endereco.numero}
       Maior de idade : {metodoPf.ValidarDataNascimento(novaPf.dataNascimento)}
      ");
      break;
    case "2":
      PessoaJuridica metodoPj = new PessoaJuridica();

      PessoaJuridica novaPj = new PessoaJuridica();
      Endereco novoEndPj = new Endereco();

      novaPj.nome = "nome PJ";
      novaPj.cnpj = "00.000.000/0001-00";
      novaPj.razaoSocial = "Razao Social PJ";
      novaPj.rendimento = 8000.5f;

      novoEndPj.longradouro = "Alameda Barão de Limeira";
      novoEndPj.numero = 539;
      novoEndPj.complemento = "SENAI Informatica";
      novoEndPj.endComercial = true;

      novaPj.endereco = novoEndPj;

      Console.WriteLine(@$"
      nome: {novaPj.nome}
      razãoSocial: {novaPj.razaoSocial}
      CNPJ: {novaPj.cnpj}
      CNPJ Válido: {metodoPj.ValidarCnpj(novaPj.cnpj)}");
      break;
    case "0":
      break;

    default:
      Console.Clear();
      Console.WriteLine($"Opçao invalida, por favor digite novamente");
      Thread.Sleep(2000);
      break;
  }

} while (opcao != "0");










