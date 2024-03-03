using System;
public class QuedaLivre
{
    public static void Main(string[] args)
    {
        const double gravidade = 9.81;

        Console.Write("Digite a altura inicial do objeto (em metros): ");
        double alturaInicial = Convert.ToDouble(Console.ReadLine());

        Console.Write("Digite o intervalo de tempo (em segundos): ");
        double intervaloTempo = Convert.ToDouble(Console.ReadLine());

        double tempo = 0;

        while (true)
        {
            double posicaoAtual = CalcularPosicao(alturaInicial, tempo, gravidade);
            double velocidadeAtual = CalcularVelocidade(tempo, gravidade);

            Console.WriteLine($"Tempo: {tempo} s - Posição: {posicaoAtual} m - Velocidade: {velocidadeAtual} m/s");

            if (posicaoAtual <= 0)
            {
                double tempoQueda = Math.Sqrt((2 * alturaInicial) / gravidade);
                Console.WriteLine("O objeto atingiu o solo em " + tempoQueda + " segundos.");
                Console.WriteLine("OBS: para realizar os cálculos, foi considerada a gravidade 9.81 m/s. Além disto, a massa dos objetos não foi considerada.");
                break;
            }

            tempo += intervaloTempo;
        }

    }

    static double CalcularPosicao(double alturaInicial, double tempo, double gravidade)
    {
        return alturaInicial - 0.5 * gravidade * Math.Pow(tempo, 2);
    }

    static double CalcularVelocidade(double tempo, double gravidade)
    {
        return gravidade * tempo;
    }
}
public class QuedaLivreTests
{
    public static void TestarCalcularPosicao()
    {
        double alturaInicial = 10.0;
        double tempo = 2.0;
        double gravidade = 9.81;

        double posicao = QuedaLivre.CalcularPosicao(alturaInicial, tempo, gravidade);
        Console.WriteLine($"Posição esperada: -5.19 m, Posição calculada: {posicao} m");
    }

    public static void TestarCalcularVelocidade()
    {
        double tempo = 2.0;
        double gravidade = 9.81;

        double velocidade = QuedaLivre.CalcularVelocidade(tempo, gravidade);
        Console.WriteLine($"Velocidade esperada: 19.62 m/s, Velocidade calculada: {velocidade} m/s");
    }

    public static void Main(string[] args)
    {
        TestarCalcularPosicao();
        TestarCalcularVelocidade();
    }
}
