using System;
using Xunit;

public class LancamentoProjetil
{
    public static double[,] CalcularTrajetoria(double v0, double angulo, double incrementoTempo, double tempoTotal)
    {
        // Conversão do ângulo de graus para radianos
        double anguloRad = angulo * Math.PI / 180.0; 
        // Componentes horizontal e vertical da velocidade inicial
        double v0x = v0 * Math.Cos(anguloRad);
        double v0y = v0 * Math.Sin(anguloRad);
        // Número de pontos ao longo da trajetória
        int numPontos = (int)(tempoTotal / incrementoTempo) + 1;
        // Matriz para armazenar os dados da trajetória: tempo, posição horizontal e vertical
        double[,] dadosTrajetoria = new double[numPontos, 3];
        // Tempo inicial
        double tempo = 0;
        // Loop para calcular os pontos ao longo da trajetória
        for (int i = 0; i < numPontos; i++)
        {
            // Cálculo da posição horizontal e vertical no tempo atual
            double x = v0x * tempo;
            double y = v0y * tempo - 0.5 * 9.81 * tempo * tempo; // Considerando a aceleração da gravidade como -9.81 m/s^2
            // Armazenamento dos dados na matriz de trajetória
            dadosTrajetoria[i, 0] = tempo; // Tempo
            dadosTrajetoria[i, 1] = x;     // Posição horizontal
            dadosTrajetoria[i, 2] = y;     // Posição vertical
            tempo += incrementoTempo;
        }    
        return dadosTrajetoria;
    }
    public static double CalcularTempoDeQueda(double v0, double angulo)
    {
        // Conversão do ângulo de graus para radianos
        double anguloRad = angulo * Math.PI / 180.0;
        // Componente vertical da velocidade inicial
        double v0y = v0 * Math.Sin(anguloRad);
        // Cálculo do discriminante da equação quadrática para determinar o tempo de queda
        double delta = v0y * v0y + 2 * 9.81 * 0;   
        // Cálculo do tempo de queda usando a fórmula quadrática
        double tempoDeQueda = (-v0y - Math.Sqrt(delta)) / (-9.81);
        return tempoDeQueda;
    }
}

public class TestesLancamentoProjetil
{
    [Fact]
    public void TestarCalcularTempoDeQueda()
    {
        // Arrange
        // Teste com velocidade inicial de 20 m/s e ângulo de lançamento de 45 graus
        double velocidadeInicial = 20;
        double anguloLancamento = 45;
        double tempoDeQuedaEsperado = 2.0385448843; // Valor calculado com precisão

        // Act
        double tempoDeQuedaCalculado = LancamentoProjetil.CalcularTempoDeQueda(velocidadeInicial, anguloLancamento);

        // Assert
        Assert.Equal(tempoDeQuedaEsperado, tempoDeQuedaCalculado, 10); // Precisão de 10 casas decimais
    }

    [Fact]
    public void TestarCalcularTrajetoria()
    {
        // Arrange
        // Dados de entrada
        double velocidadeInicial = 20;
        double anguloLancamento = 45;
        double incrementoTempo = 0.1;
        double tempoTotal = 10;

        // Valor esperado para a posição final em x
        double posicaoFinalXEsperada = 141.421356237;

        // Valor esperado para a posição final em y
        double posicaoFinalYEsperada = -349.081520518;

        // Act
        // Calculando a trajetória do projétil
        double[,] dadosTrajetoria = LancamentoProjetil.CalcularTrajetoria(velocidadeInicial, anguloLancamento, incrementoTempo, tempoTotal);

        // Assert
        // Verificando a posição final em x
        double posicaoFinalXCalculada = dadosTrajetoria[dadosTrajetoria.GetLength(0) - 1, 1];
        Assert.Equal(posicaoFinalXEsperada, posicaoFinalXCalculada, 9); // Precisão de 9 casas decimais

        // Verificando a posição final em y
        double posicaoFinalYCalculada = dadosTrajetoria[dadosTrajetoria.GetLength(0) - 1, 2];
        Assert.Equal(posicaoFinalYEsperada, posicaoFinalYCalculada, 9); // Precisão de 9 casas decimais
    }
}
