using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while ( opcaoUsuario.ToUpper() != "X")
            {
                switch ( opcaoUsuario )
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        public static void ListarSeries()
        {
            Console.WriteLine("Listar series");
            var list = repositorio.Lista();

            if ( list.Count == 0 )
            {
                Console.WriteLine("Nennhuma serie cadastrada.");
                return;
            }

            foreach ( var serie in list )
            {
                var excluido = serie.Excluido;
                
                if ( !excluido )
                {
                    Console.WriteLine($"#ID {serie.Id}: - {serie.retornaTitulo()}");
                }
            }
        }

        public static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie: ");

            // Output dos valores enumerados!
            foreach ( int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{ i } { Enum.GetName(typeof(Genero), i ) }");
            }

            Console.WriteLine("Digite o genero entre as opcoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descricao da serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaserie = new Serie( id : repositorio.ProximoId(),
                                         genero : (Genero)entradaGenero,
                                         titulo : entradaTitulo,
                                         ano : entradaAno,
                                         descricao : entradaDescricao );

            repositorio.Insere(novaserie);
        }
        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da serie: ");
            int indiceSerie = Convert.ToInt32(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine( $"{i} - {Enum.GetName( typeof(Genero), i )}");
            }

            Console.WriteLine("Digite o genero entre as opcoes acima: ");
            int entradaGenero = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da serie: ");
            int entradaAno = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite a descricao da serie: ");
            string entradaDescricao = Console.ReadLine();

            //!!!! Uso do Cast para dizer ao construtor do tipo Serie que o inteiro entradaGenero eh do tipo enumerado Genero!!!
            Serie atualizaSerie = new Serie( id : indiceSerie,
                                         genero : (Genero)entradaGenero,
                                         titulo : entradaTitulo,
                                         descricao : entradaDescricao,
                                         ano : entradaAno);

            repositorio.Atualiza( id : indiceSerie, obj : atualizaSerie);
        }

        public static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da serie: ");
            int entradaId = Convert.ToInt32(Console.ReadLine());

            try
            {
                repositorio.Excluir( id : entradaId );
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Serie Removida!!!");
        }

        public static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da serie: ");
            int entradaId = Convert.ToInt32(Console.ReadLine());

            var obj = repositorio.RetornaPorId( entradaId );
            Console.WriteLine( obj );
        }
        public static string ObterOpcaoUsuario()
        {
            Console.WriteLine(Environment.NewLine + "DIO Series a seu dispor!!!");
            Console.WriteLine("Informe a opcao desejada: ");

            Console.WriteLine("1 - Listar Series");
            Console.WriteLine("2 - Inserir nova serie");
            Console.WriteLine("3 - Atualizar serie");
            Console.WriteLine("4 - Excluir serie");
            Console.WriteLine("5 - Visualizar serie");
            Console.WriteLine("C - Limprar Tela");
            Console.WriteLine("X - Sair" + Environment.NewLine);
            
            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }
    }
}
