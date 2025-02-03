namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class DeflectorA : Deflector
{
    private const double DeflectorAArmor = 50;

    public DeflectorA(PhotonDeflector? photonDeflector)
    {
        PhotonDeflector = photonDeflector;
        Armor = DeflectorAArmor;
    }
}