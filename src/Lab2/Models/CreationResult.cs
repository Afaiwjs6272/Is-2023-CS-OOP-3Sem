using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class CreationResult
{
    public CreationResult(Computer computer, ComputerValidationErrors validationErrors)
    {
        Computer = computer;
        ValidationErrors = validationErrors;
    }

    public Computer Computer { get; }
    public ComputerValidationErrors ValidationErrors { get; }
}