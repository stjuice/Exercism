using System;
using System.Collections.Generic;

public enum Allergen {
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies {
    private Allergen allergen { get; }

    public Allergies(int mask) 
    {
        allergen = (Allergen) mask;
    }

    public bool IsAllergicTo(Allergen value) 
    {
        return ((allergen & value) == value);
    }

    public Allergen[] List() 
    {
        if (allergen == 0)
            return new Allergen[] { };

        var list = new List<Allergen>();

        var allergens = Enum.GetValues(typeof(Allergen));

        foreach (var item in allergens) 
        {
            if ((allergen & (Allergen) item) == (Allergen) item)
                list.Add((Allergen) item);
        }

        return list.ToArray();
    }
}