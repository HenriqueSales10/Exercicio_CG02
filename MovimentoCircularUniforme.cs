using System;
using Xunit;

public class MovimentoCircularUniforme
{
    private double raio;
    private double velocidadeAngular;

    public MovimentoCircularUniforme(double raio, double velocidadeAngular)
    {
        this.raio = raio;
        this.velocidadeAngular = velocidadeAngular;
    }

    // Calcula a velocidade tangencial utilizando a fórmula v = r * ω
    public double CalcularVelocidadeTangencial()
    {
        return raio * velocidadeAngular;
    }

    // Calcula a aceleração centrípeta utilizando a fórmula a = ω^2 * r
    public double CalcularAceleracaoCentripeta()
    {
        return Math.Pow(velocidadeAngular, 2) * raio;
    }

    [Fact]
    public void TestarVelocidadeTangencial()
    {
        double raio = 2.0;
        double velocidadeAngular = 3.0;
        MovimentoCircularUniforme movimento = new MovimentoCircularUniforme(raio, velocidadeAngular);

        double velocidadeTangencialCalculada = movimento.CalcularVelocidadeTangencial();
        double velocidadeTangencialEsperada = raio * velocidadeAngular;

        Assert.Equal(velocidadeTangencialEsperada, velocidadeTangencialCalculada, 5); // Com margem de erro de 5 casas decimais
    }

    [Fact]
    public void TestarAceleracaoCentripeta()
    {
        double raio = 2.0;
        double velocidadeAngular = 3.0;
        MovimentoCircularUniforme movimento = new MovimentoCircularUniforme(raio, velocidadeAngular);

        double aceleracaoCentripetaCalculada = movimento.CalcularAceleracaoCentripeta();
        double aceleracaoCentripetaEsperada = Math.Pow(velocidadeAngular, 2) * raio;

        Assert.Equal(aceleracaoCentripetaEsperada, aceleracaoCentripetaCalculada, 5); // Com margem de erro de 5 casas decimais
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Cálculo de Movimento Circular Uniforme");

        Console.Write("Digite o raio da trajetória circular (em metros): ");
        double raio = double.Parse(Console.ReadLine());

        Console.Write("Digite a velocidade angular (em rad/s): ");
        double velocidadeAngular = double.Parse(Console.ReadLine());

        MovimentoCircularUniforme movimento = new MovimentoCircularUniforme(raio, velocidadeAngular);

        double velocidadeTangencial = movimento.CalcularVelocidadeTangencial();
        double aceleracaoCentripeta = movimento.CalcularAceleracaoCentripeta();

        Console.WriteLine($"Velocidade tangencial: {velocidadeTangencial} m/s");
        Console.WriteLine($"Aceleração centrípeta: {aceleracaoCentripeta} m/s^2");
    }
}
