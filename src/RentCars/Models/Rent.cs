using RentCars.Types;

namespace RentCars.Models;

public class Rent
{
    private double _price;

    public Vehicle Vehicle { get; set; }
    public Person Person { get; set; }
    public int DaysRented { get; set; }
    public RentStatus Status { get; set; }
    public double Price
    {
        get { return _price; }
        set
        {
            if (Person is LegalPerson)
            {
                _price = value * 0.1;
            }
            else
            {
                _price = value;
            }
        }
    }

    //10 - Crie o construtor de `Rent` seguindo as regras de negócio
    public Rent(Vehicle vehicle, Person person, int daysRented)
    {
        Vehicle = vehicle;
        Person = person;
        DaysRented = daysRented;
        Price = Vehicle.PricePerDay * DaysRented;
        Status = RentStatus.Confirmed;

        Vehicle.IsRented = true;
        Person.Debit = Price;
    }

    //11 - Implemente os métodos de `cancelar` e `finalizar` um aluguel
    public void Cancel()
    {
        Status = RentStatus.Canceled;
    }

    //11 - Implemente os métodos de `cancelar` e `finalizar` um aluguel
    public void Finish()
    {
        Status = RentStatus.Finished;
    }
}
