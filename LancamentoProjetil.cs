using System;

public class LancamentoProjetil
{
    public static double[,] CalcularTrajetoria(double v0, double angulo, double incrementoTempo, double tempoTotal)
    {
        double anguloRad = angulo * Math.PI / 180.0;
        double v0x = v0 * Math.Cos(anguloRad);
        double v0y = v0 * Math.Sin(anguloRad);
        int numPontos = (int)(tempoTotal / incrementoTempo) + 1;
        double[,] dadosTrajetoria = new double[numPontos, 3];
        double tempo = 0;

        for (int i = 0; i < numPontos; i++)
        {
            double x = v0x * tempo;
            double y = v0y * tempo - 0.5 * 9.81 * tempo * tempo;

            dadosTrajetoria[i, 0] = tempo;
            dadosTrajetoria[i, 1] = x;
            dadosTrajetoria[i, 2] = y;

            tempo += incrementoTempo;
        }

        return dadosTrajetoria;
    }

    public static double CalcularTempoDeQueda(double v0, double angulo)
    {
        double anguloRad = angulo * Math.PI / 180.0;
        double v0y = v0 * Math.Sin(anguloRad);
        double delta = v0y * v0y + 2 * 9.81 * 0;
        double tempoDeQueda = (-v0y - Math.Sqrt(delta)) / (-9.81);
        return tempoDeQueda;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Digite a velocidade inicial (m/s):");
        double v0 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Digite o ângulo de lançamento (graus):");
        double angulo = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Digite o incremento de tempo (s):");
        double incrementoTempo = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Digite o tempo total (s):");
        double tempoTotal = Convert.ToDouble(Console.ReadLine());

        double[,] dadosTrajetoria = LancamentoProjetil.CalcularTrajetoria(v0, angulo, incrementoTempo, tempoTotal);

        Console.WriteLine("Tempo\tPosição X\tPosição Y");
        for (int i = 0; i < dadosTrajetoria.GetLength(0); i++)
        {
            Console.WriteLine($"{dadosTrajetoria[i, 0]:F2}\t{dadosTrajetoria[i, 1]:F2}\t\t{dadosTrajetoria[i, 2]:F2}");
        }
        Console.WriteLine($"Tempo até o projétil atingir o solo: {LancamentoProjetil.CalcularTempoDeQueda(v0, angulo)} segundos");
        Console.WriteLine("Nota: A aceleração de gravidade foi assumida como 9.81 m/s^2");
    }
}
[TestClass]
public class TestesLancamentoProjetil
{
    [TestMethod]
    public void TestarCalcularTempoDeQueda()
    {
        // Teste com velocidade inicial de 20 m/s e ângulo de lançamento de 45 graus
        double velocidadeInicial = 20;
        double anguloLancamento = 45;
        double tempoDeQuedaEsperado = 2.0385448843; // Valor calculado com precisão

        double tempoDeQuedaCalculado = LancamentoProjetil.CalcularTempoDeQueda(velocidadeInicial, anguloLancamento);

        Assert.AreEqual(tempoDeQuedaEsperado, tempoDeQuedaCalculado, 0.0000000001); // Precisão de 10 casas decimais
    }

    [TestMethod]
    public void TestarCalcularTrajetoria()
    {
        // Dados de entrada
        double velocidadeInicial = 20;
        double anguloLancamento = 45;
        double incrementoTempo = 0.1;
        double tempoTotal = 10;

        // Valor esperado para a posição final em x
        double posicaoFinalXEsperada = 141.421356237;

        // Valor esperado para a posição final em y
        double posicaoFinalYEsperada = -349.081520518;

        // Calculando a trajetória do projétil
        double[,] dadosTrajetoria = LancamentoProjetil.CalcularTrajetoria(velocidadeInicial, anguloLancamento, incrementoTempo, tempoTotal);

        // Verificando a posição final em x
        double posicaoFinalXCalculada = dadosTrajetoria[dadosTrajetoria.GetLength(0) - 1, 1];
        Assert.AreEqual(posicaoFinalXEsperada, posicaoFinalXCalculada, 0.000000001); // Precisão de 9 casas decimais

        // Verificando a posição final em y
        double posicaoFinalYCalculada = dadosTrajetoria[dadosTrajetoria.GetLength(0) - 1, 2];
        Assert.AreEqual(posicaoFinalYEsperada, posicaoFinalYCalculada, 0.000000001); // Precisão de 9 casas decimais
    }
}
