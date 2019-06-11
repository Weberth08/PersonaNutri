namespace PersonalNutri.UI.Console.Util
{
   public static  class ConsoleUtil
    {
        public static void EscreverNovaLinha(string texto)
        {
            System.Console.WriteLine(texto);
        }
        public static void Escrever(string texto)
        {
            System.Console.Write(texto);
        }

        public static void LimparConsole()
        {
            System.Console.Clear();
        }

        public static string LerEntradaDoUsuario()
        {
            return System.Console.ReadLine();
        }
    }

}
