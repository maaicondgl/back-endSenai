// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Cadastro_Pessoa_FS1.Classes;

Console.WriteLine(@$"
==================================================
| Bem vindo ao Sistema de cadastro de            | 
|      Pessoa Fisicas e Juridicas                 |
================================================== 
");
BarraCarregamento("Carregando ", 500);
List<PessoaFisica> listaPf = new List<PessoaFisica>();
string opcao;

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


      string opcaoPf;
      do
      {
        Console.Clear();
        Console.WriteLine(@$"
 =======================================================
 |           Escolha uma das opçoes abaixo              |
 |           1 - cadastrar Pessoa  fisica               |
 |           2 - mostrar Pessoas Fisicas                |
 |                                                      |
 |            0 - Voltar ao menu anterior               |
 |                                                      |
 =======================================================
 ");
        opcaoPf = Console.ReadLine();
        switch (opcaoPf)
        {
          case "1":
            PessoaFisica novaPf = new PessoaFisica();
            Endereco novoEnd = new Endereco();

            Console.WriteLine($"Digite o nome da pessoa fisica que deseja cadastrar");
            novaPf.nome = Console.ReadLine();

            bool dataValida;
            do
            {
              Console.WriteLine($"Digite a data de nascimento Ex:DD/MM/AAAA");
              string? dateNasc = Console.ReadLine();
              dataValida = metodoPf.ValidarDataNascimento(dateNasc);
              if (dataValida)
              {
                novaPf.dataNascimento = dateNasc;
              }
              else
              {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Data digitada invalida,por favor digite uma data Valida");
                Console.ResetColor();
              }
            } while (dataValida == false);

            Console.WriteLine($"Digite o numero do CPF");
            novaPf.cpf = Console.ReadLine();

            Console.WriteLine($"Digite o rendimento mensal(digite somente numeros)");
            novaPf.rendimento = float.Parse(Console.ReadLine());

            Console.WriteLine($"Digite o longradouro");
            novoEnd.longradouro = Console.ReadLine();

            Console.WriteLine($"Digite o numero");
            novoEnd.numero = int.Parse(Console.ReadLine());

            Console.WriteLine($"Digite o complemento(aperte ENTER para vazio)");
            novoEnd.complemento = Console.ReadLine();

            Console.WriteLine($"Este endereço é comercial? S/N");
            string endCom = Console.ReadLine().ToUpper();
            if (endCom == "S")
            {
              novoEnd.endComercial = true;
            }
            else
            {
              novoEnd.endComercial = false;
            }

            novaPf.endereco = novoEnd;
            // listaPf.Add(novaPf);

            //  StreamWriter sw = new StreamWriter($"{novaPf.nome}.txt");
            //  sw.Write("novaPf.nome");
            //  sw.Close();

            using (StreamWriter sw = new StreamWriter($"{novaPf.nome}.txt"))
            {
              sw.WriteLine($"{novaPf.nome}{novaPf.cpf}{novaPf.dataNascimento}{novaPf.endereco}");

            }






            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Cadastro realizado com sucesso");
            Thread.Sleep(4000);
            Console.ResetColor();
            break;
          case "2":
            //       Console.Clear();
            //       if (listaPf.Count > 0)
            //       {
            //         foreach (PessoaFisica cadaPessoa in listaPf)
            //         {
            //           Console.Clear();
            //           Console.WriteLine(@$"
            //  Nome: {cadaPessoa.nome}
            //  Endereço: {cadaPessoa.endereco.longradouro}, {cadaPessoa.endereco.numero}
            //  Maior de idade : {cadaPessoa.dataNascimento}
            //  Taxa de imposto a ser paga é: {metodoPf.PagarImposto(cadaPessoa.rendimento).ToString("C")}
            // ");


            //           Console.WriteLine($"aperte 'Enter' Para continuar");
            //           Console.ReadLine();
            //         }
            //       }
            //       else
            //       {
            //         Console.WriteLine($"Lista vazia!!");
            //         Thread.Sleep(3000);
            //       }
            using (StreamReader sr = new StreamReader("maicondouglas.txt"))
            {
              string linha;
              while ((linha = sr.ReadLine()) != null)
              {
                Console.WriteLine($"{linha}");

              }
            }
            Console.WriteLine($"aperte 'Enter' Para continuar");
            Console.ReadLine();
            break;
          case "0":
            break;
          default:
            Console.Clear();
            Console.WriteLine($"Opçao invalida, por favor digite novamente");
            Thread.Sleep(2000);
            break;
        }


      } while (opcaoPf != "0");





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


      metodoPj.Inserir(novaPj);
      List<PessoaJuridica> ListaPj = metodoPj.ler();
      foreach (PessoaJuridica cadaItem in ListaPj)
      {
        Console.Clear();
        Console.WriteLine(@$"
      nome: {novaPj.nome}
      razãoSocial: {novaPj.razaoSocial}
      CNPJ: {novaPj.cnpj}
      CNPJ Válido: {metodoPj.ValidarCnpj(novaPj.cnpj)}");
      }

      break;
    case "0":
      Console.Clear();
      Console.WriteLine($"Obrigado por utilizar nosso sistema");
      BarraCarregamento("finalizando", 300);

      break;

    default:
      Console.Clear();
      Console.WriteLine($"Opçao invalida, por favor digite novamente");
      Thread.Sleep(2000);
      break;
  }

} while (opcao != "0");


static void BarraCarregamento(string texto, int tempo)
{
  Console.BackgroundColor = ConsoleColor.DarkBlue;
  Console.ForegroundColor = ConsoleColor.Black;
  Console.Write($"{texto} ");

  for (var contador = 0; contador < 10; contador++)
  {
    Console.Write(". ");
    Thread.Sleep(tempo);
  }
  Console.ResetColor();

}








