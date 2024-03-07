using System;
using Xunit;

public class QuedaLivre
{
    private static double CalcularPosicao(double alturaInicial, double tempo, double gravidade)
    {
        // Calcula a posição usando a fórmula da cinemática para queda livre.
        // A posição é dada pela altura inicial menos metade da aceleração gravitacional multiplicada pelo quadrado do tempo.
        return alturaInicial - 0.5 * gravidade * Math.Pow(tempo, 2);
    }

    private static double CalcularVelocidade(double tempo, double gravidade)
    {
         // Calcula a velocidade usando a fórmula da cinemática para queda livre.
        // A velocidade é dada pela aceleração gravitacional multiplicada pelo tempo.
        return gravidade * tempo;
    }
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
}
public class QuedaLivreTests
{
    public static void TestarCalcularPosicao()
    {
        // Arrange
        double alturaInicial = 10.0;
        double tempo = 2.0;
        double gravidade = 9.81;

         // Act
        double posicao = QuedaLivre.CalcularPosicao(alturaInicial, tempo, gravidade);
        // Assert
        Console.WriteLine($"Posição esperada: -5.19 m, Posição calculada: {posicao} m");
    }

    public static void TestarCalcularVelocidade()
    {
        // Arrange
        double tempo = 2.0;
        double gravidade = 9.81;

         // Act
        double velocidade = QuedaLivre.CalcularVelocidade(tempo, gravidade);
        // Assert
        Console.WriteLine($"Velocidade esperada: 19.62 m/s, Velocidade calculada: {velocidade} m/s");
    }
}
