namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class DeflectorC : Deflector
{
    private const double DeflectorCArmor = 400;

    public DeflectorC(PhotonDeflector? photonDeflector)
    {
        PhotonDeflector = photonDeflector;
        Armor = DeflectorCArmor;
    }
}