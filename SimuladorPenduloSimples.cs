using System;
using Xunit;

public class SimuladorPenduloSimples
{
    private double comprimento;
    private double gravidade = 9.81; // Aceleração devido à gravidade (m/s^2)

    public SimuladorPenduloSimples(double comprimento)
    {
        this.comprimento = comprimento;
    }

    public double CalcularPosicaoAngular(double massa, double tempo)
    {
        double frequenciaAngular = Math.Sqrt(gravidade / comprimento);
        double posicaoAngular = Math.PI / 2 * Math.Cos(frequenciaAngular * tempo);
        return posicaoAngular;
    }

    [Fact]
    public void TestarPosicaoAngularEmRepouso()
    {
        // Arrange
        double massa = 1.0; // Massa do objeto pendurado (kg)
        double tempo = 0; // Tempo (s)

        // Act
        double posicaoAngular = CalcularPosicaoAngular(massa, tempo);

        // Assert
        Assert.Equal(Math.PI / 2, posicaoAngular, 5); // Com margem de erro de 5 casas decimais
    }

    [Fact]
    public void TestarPosicaoAngularEmTempo()
    {
        // Arrange
        double massa = 1.0; // Massa do objeto pendurado (kg)
        double tempo = 1; // Tempo (s)

        // Act
        double posicaoAngular = CalcularPosicaoAngular(massa, tempo);

        // Assert
        Assert.Equal(0, posicaoAngular, 5); // Com margem de erro de 5 casas decimais
    }
}

public class Programa
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Simulação de Pêndulo");
        Console.Write("Digite o comprimento da corda (em metros): ");
        double comprimento = double.Parse(Console.ReadLine());

        Console.Write("Digite a massa do objeto pendurado (em kg): ");
        double massa = double.Parse(Console.ReadLine());

        SimuladorPenduloSimples simulador = new SimuladorPenduloSimples(comprimento);

        Console.WriteLine("Simulação iniciada. Digite o tempo (em segundos) para calcular a posição angular do pêndulo.");
        double tempo = double.Parse(Console.ReadLine());

        double posicaoAngular = simulador.CalcularPosicaoAngular(massa, tempo);
        Console.WriteLine($"Posição angular do pêndulo em {tempo} segundos: {posicaoAngular} radianos.");
        Console.WriteLine($"Para calcular a posição, foi considerada a gravidade de 9.81 (m/s^2).");
    }
}
