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
        // A frequência angular é a raiz quadrada da gravidade dividida pelo comprimento do pêndulo.
        double frequenciaAngular = Math.Sqrt(gravidade / comprimento);

        // A posição angular é dada pela metade de pi multiplicada pelo cosseno da frequência angular multiplicada pelo tempo.
        double posicaoAngular = Math.PI / 2 * Math.Cos(frequenciaAngular * tempo);
        return posicaoAngular;
    }
}

public class SimulacaoPenduloTests
{
    [Fact]
    public void TestarPosicaoAngularEmRepouso()
    {
        // Arrange
        double comprimento = 1.0; // Comprimento da corda (m)
        SimuladorPenduloSimples simulador = new SimuladorPenduloSimples(comprimento);
        double massa = 1.0; // Massa do objeto pendurado (kg)
        double tempo = 0; // Tempo (s)

        // Act
        double posicaoAngular = simulador.CalcularPosicaoAngular(massa, tempo);

        // Assert
        Assert.Equal(Math.PI / 2, posicaoAngular, 5); // Com margem de erro de 5 casas decimais
    }

    [Fact]
    public void TestarPosicaoAngularEmTempo()
    {
        // Arrange
        double comprimento = 1.0; // Comprimento da corda (m)
        SimuladorPenduloSimples simulador = new SimuladorPenduloSimples(comprimento);
        double massa = 1.0; // Massa do objeto pendurado (kg)
        double tempo = 1; // Tempo (s)

        // Act
        double posicaoAngular = simulador.CalcularPosicaoAngular(massa, tempo);

        // Assert
        Assert.Equal(0, posicaoAngular, 5); // Com margem de erro de 5 casas decimais
    }
}
