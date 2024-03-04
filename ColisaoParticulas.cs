using System;
using Xunit;

public class Particula
{
    public double Massa { get; set; }
    public double VelocidadeX { get; set; }
    public double VelocidadeY { get; set; }

    public Particula(double massa, double velocidadeX, double velocidadeY)
    {
        Massa = massa;
        VelocidadeX = velocidadeX;
        VelocidadeY = velocidadeY;
    }

    public void Colidir(Particula outraParticula)
    {
        double m1 = Massa;
        double m2 = outraParticula.Massa;
        double u1 = VelocidadeX;
        double v1 = VelocidadeY;
        double u2 = outraParticula.VelocidadeX;
        double v2 = outraParticula.VelocidadeY;

        double xDiff = u2 - u1;
        double yDiff = v2 - v1;

        double xDist = outraParticula.VelocidadeX - VelocidadeX;
        double yDist = outraParticula.VelocidadeY - VelocidadeY;

        double produtoEscalar = xDiff * xDist + yDiff * yDist;

        double escalaColisao = produtoEscalar / ((m1 + m2) * (xDist * xDist + yDist * yDist));

        double xColisao = xDist * escalaColisao;
        double yColisao = yDist * escalaColisao;

        VelocidadeX += xColisao / m1;
        VelocidadeY += yColisao / m1;

        outraParticula.VelocidadeX -= xColisao / m2;
        outraParticula.VelocidadeY -= yColisao / m2;
    }
}

public class Programa
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Digite os dados da Partícula 1:");
        Console.Write("Massa: ");
        double massa1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Velocidade X: ");
        double velocidadeX1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Velocidade Y: ");
        double velocidadeY1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\nDigite os dados da Partícula 2:");
        Console.Write("Massa: ");
        double massa2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Velocidade X: ");
        double velocidadeX2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Velocidade Y: ");
        double velocidadeY2 = Convert.ToDouble(Console.ReadLine());

        Particula particula1 = new Particula(massa1, velocidadeX1, velocidadeY1);
        Particula particula2 = new Particula(massa2, velocidadeX2, velocidadeY2);

        Console.WriteLine("\nAntes da colisão:");
        Console.WriteLine("Partícula 1 - Velocidade X: " + particula1.VelocidadeX + ", Velocidade Y: " + particula1.VelocidadeY);
        Console.WriteLine("Partícula 2 - Velocidade X: " + particula2.VelocidadeX + ", Velocidade Y: " + particula2.VelocidadeY);

        particula1.Colidir(particula2);

        Console.WriteLine("\nApós a colisão:");
        Console.WriteLine("Partícula 1 - Velocidade X: " + particula1.VelocidadeX + ", Velocidade Y: " + particula1.VelocidadeY);
        Console.WriteLine("Partícula 2 - Velocidade X: " + particula2.VelocidadeX + ", Velocidade Y: " + particula2.VelocidadeY);
    }
}
public class ParticulaTests
{
    [Fact]
    public void Colisao_EntreParticulas_VelocidadesAtualizadasCorretamente()
    {
        // Arrange
        var particula1 = new Particula(1.0, 2.0, 3.0);
        var particula2 = new Particula(2.0, -1.0, 4.0);

        // Act
        particula1.Colidir(particula2);

        // Assert
        Assert.Equal(1.6, Math.Round(particula1.VelocidadeX, 2)); // Velocidade X esperada após a colisão
        Assert.Equal(3.2, Math.Round(particula1.VelocidadeY, 2)); // Velocidade Y esperada após a colisão
        Assert.Equal(0.4, Math.Round(particula2.VelocidadeX, 2)); // Velocidade X esperada após a colisão
        Assert.Equal(3.8, Math.Round(particula2.VelocidadeY, 2)); // Velocidade Y esperada após a colisão
    }
}
