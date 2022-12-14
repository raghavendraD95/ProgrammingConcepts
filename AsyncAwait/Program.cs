// See https://aka.ms/new-console-template for more information
Console.WriteLine("Begin data aggregation!");

var b = new MainClass();
await b.BeginProcess();

Console.WriteLine("End data aggregation!");


public class MainClass
{
    public async Task BeginProcess()
    {
        try
        {

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            OvenKitchen ovenKitchen = new OvenKitchen();
            
            VegetablesKitchen vegetableKitchen = new VegetablesKitchen();

            Console.WriteLine("Starting the bread baking process");

            Task<string> breadBakingTask = ovenKitchen.BakeBread();

            Console.WriteLine("Getting the veggies");

            string vegetables = await vegetableKitchen.GettingVegetablesReady();

            Console.WriteLine("Washing the vegetables:"+ vegetables);

            Console.WriteLine("Taking 5 seconds to chop vegetables");

            await Task.Delay(5000);

            Console.WriteLine("Vegetables are done");

            Console.WriteLine("Now waiting for the bread task to be completed");

            string finishedBread = await breadBakingTask;

            Console.WriteLine(DateTime.Now.ToString());

            Console.WriteLine("Getting marks data");

            string sandwich = await ovenKitchen.MakeSandwich(finishedBread, vegetables);

            watch.Stop();
            Console.WriteLine($"Execution Time:{ watch.ElapsedMilliseconds} ms");

        }
        catch (Exception ex)
        {

            throw;
        }
    }

}







public class OvenKitchen
{

    public async Task<string> BakeBread()
    {
        Console.WriteLine("Warming the oven");

        Console.WriteLine(DateTime.Now.ToString());

        await Task.Delay(10000);

        Console.WriteLine("Bread is baked!");

        return "Normal bread";
    }

    public async Task<string> MakeSandwich(string bread, string vegetables)
    {

        Console.WriteLine("Initiating Sandwich making process");

        await Task.Delay(4000);

        Console.WriteLine("Veg Sandwich Made");

        return "Veg sandwich";
    }
}



public class VegetablesKitchen
{

    public async Task<string> GettingVegetablesReady()
    {
        Console.WriteLine("Get the veggies from the market");

        await Task.Delay(3000);

        Console.WriteLine("Veggies from market came");

        return "Tomatoes and spinach";
    }
}