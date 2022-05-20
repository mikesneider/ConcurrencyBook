// See https://aka.ms/new-console-template for more information
using System.Diagnostics;


await DosomethingFirst(); //if I type the "await" then program will wait for this function
//All the async void, must be Task type at least
Console.WriteLine("Concurrency in C#");
await TrySomethingAsync();

async Task DosomethingFirst()
{
    int myvalue = 10;
    await Task.Delay(1000).ConfigureAwait(false); //This will run async, If I really want to wait I have to put
                                                  // .ConfigureAwait(false)
    Trace.WriteLine(myvalue);
    myvalue *= 2;
    await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
    Console.WriteLine("The value is this {0} one", myvalue);
    Trace.WriteLine("The value is this one", myvalue.ToString()); //This is for diagnostics, will not appear in the console
}
//most of the time await will take a Task or Task<TResult>.
//How to handle exceptions for Async methods?
async Task TrySomethingAsync()
{

    try
    {
       await DosomethingFirst();
    }
    catch (NotSupportedException ex)
    {
        //catch the Exception in a log
        throw;
    }
}
//Intro to Parallel , in parallel you can user Parallel.ForEach
void RotateMatrices(IEnumerable<Matrix> matrices, float degrees)
{
    Parallel.ForEach(matrices, m => m.Rotate(degrees));
}

public class Matrix
{
    //some MAtrix
    public void Rotate(float grados)
    {
        new NotImplementedException();
    }
}
//Also exists the PLINQ (Parallel LINQ)
IEnumerable<bool> PrimalityTest(IEnumerable<int> values)
{
    return values.AsParallel().Select(v=>IsPrime(v));
} 
 bool IsPrime(int value)
{
    if (value < 0)
        return false;
    return true;
}