using System;  // importa la biblioteca estándar para entrada y salida de datos

class Program  // definimos la clase principal
{
    static void Main()  // método principal donde inicia la ejecución del programa.
    {
        do  // iniciamos un bucle para repetir el cálculo si el usuario lo desea.
        {
            Console.Clear();  // limpia la pantalla cada vez que se inicia un nuevo cálculo.
            Console.WriteLine("Cálculo de Tabla de Amortización");  // muestra el título del programa

            // solicitamos los datos del cliente
            Console.Write("Ingrese el nombre del cliente: ");
            string cliente = Console.ReadLine();  // guarda el nombre ingresado.

            Console.Write("Ingrese la cedula del cliente: ");
            string cedula = Console.ReadLine();  // guarda la cédula ingresada.

            // solicitamos los datos del préstamo
            Console.Write("Ingrese el monto del prestamo: ");
            double monto = Convert.ToDouble(Console.ReadLine());  // convierte la entrada en número decimal.

            Console.Write("Ingrese el periodo en años: ");
            int anios = Convert.ToInt32(Console.ReadLine());  // convierte la entrada en número entero.

            Console.Write("Ingrese la tasa de interes mensual (en porcentaje, ej. 1.5 para 1.5%): ");
            double tasaInteresMensual = Convert.ToDouble(Console.ReadLine()) / 100;  // convierte el porcentaje a decimal.

            // calculo de la cuota mensual utilizando la fórmula de amortización sacada de internet
            int meses = anios * 12;  // convierte años a meses.

            //te explico aqui para sacar la cuota mensual famosa.
            //multiplicamos el monto por la tasa de interés mensual (monto * tasaInteresMensual), eso calcula cuánto interés se genera en el primer mes antes de aplicar la amortización
            //luego use el Math.pow para elevar (1 + tasaInteresMensual) a la potencia -meses 
            // Math.Pow(base, exponente) es una función matemática en C# que se usa para elevar un número a una potencia
            // (1 + tasaInteresMensual) te suma 1 a la tasa mensual para considerar el crecimiento del capital
            // Math.Pow(..., -meses) → Eleva al exponente -meses, lo que representa el descuento del interés en el tiempo.
            // luego restamos 1 al resultado de la potencia, esto controla como se distribuye la amortización a lo largo del tiempo.
            double cuotaMensual = (monto * tasaInteresMensual) / (1 - Math.Pow(1 + tasaInteresMensual, -meses));

            // Mostrar información del préstamo
            Console.WriteLine("\n---------------------------------------------------");
            Console.WriteLine($"Cliente: {cliente}");  // muestra el nombre del cliente.
            Console.WriteLine($"Cedula: {cedula}");  // muestra la cédula del cliente.
            Console.WriteLine($"Monto del prestamo: {monto:F2}");  // formato de 2 decimales.
            Console.WriteLine($"Periodo en meses: {meses}");  // muestra el periodo en meses.
            Console.WriteLine($"Tasa de interes mensual: {tasaInteresMensual * 100:F1}%");  // muestra la tasa en porcentaje.
            Console.WriteLine($"Cuota mensual: {cuotaMensual:F2}");  // muestra el valor de la cuota mensual.
            Console.WriteLine("---------------------------------------------------\n");

            // encabezado de la tabla
            Console.WriteLine("NO\tCAPITAL\t\tINTERES\t\tCAPITAL + INTERES\tCUOTA\t\tSALDO");

            double saldo = monto;  // se inicia el saldo con el monto del préstamo.

            // Se usa el ciclo for para poder generar la tabla de amortización
            for (int i = 1; i <= meses; i++)
            {
                double interes = saldo * tasaInteresMensual;  // calcula el interés del mes.
                double capitalPagado = cuotaMensual - interes;  // calcula cuánto capital se está pagando.
                saldo -= capitalPagado;  // resta el capital pagado al saldo.

                // imprime cada fila de la tabla con formato alineado.
                Console.WriteLine($"{i}\t{saldo + capitalPagado,10:F2}\t{interes,8:F2}\t{saldo + capitalPagado + interes,15:F2}\t{cuotaMensual,8:F2}\t{saldo,10:F2}");
            }

            // preguntar al usuario si desea calcular nuevamente sin tener que estar reinciando manual
            Console.WriteLine("\n Desea calcular otra amortización? (S/N)");
        }
        while (Console.ReadLine().Trim().ToUpper() == "S");  // Repite el proceso si el usuario ingresa "S".

        // mensaje de finalización.
        Console.WriteLine(" Programa finalizado. ¡Gracias por usar el calculador de amortización!");
    }
}
