package teste;

import java.util.Scanner;
public class Exercicio {
    public static void main (String[]args) 
    	{
        
        }
	    private int CalcularVelocidadeQuedaLivre() {
	    	Scanner sc = new Scanner(System.in);  
	    	int intervaloTempo = 0;
	    	int aceleracaoGravidade; 
	    	
	        System.out.println("Informe o intervalo de tempo em m/s:");
	        intervaloTempo = sc.nextInt();
	        
	        System.out.println("Informe a aceleração da gravidade (Obs: a aceleração de gravidade padrão é 9.8 m/s) :");
	        aceleracaoGravidade = sc.nextInt();

	        System.out.println("A velocidade do corpo em queda livre é de:" + (intervaloTempo * aceleracaoGravidade) +" m/s ");

	        
	        sc.close();
	        return 0;
	    }
    }
