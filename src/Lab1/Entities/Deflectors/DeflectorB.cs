namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class DeflectorB : Deflector
{
    private const double DeflectorBArmor = 100;

    public DeflectorB(PhotonDeflector? photonDeflector)
    {
        PhotonDeflector = photonDeflector;
        Armor = DeflectorBArmor;
    }
}