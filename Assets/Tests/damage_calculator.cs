using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class damage_calculator
{
    [Test]
    public void sets_damage_to_half_with_50_percent_mitigation()
    {
        int finalDamage = DamageCalculator.CalculateDamage(amount: 10, mitigationPercent: 0.5f);

        Assert.AreEqual(expected: 5, actual: finalDamage);
    }

    [Test]
    public void calculates_2_damage_from_10_with_80_percent_mitigation()
    {
        int finalDamage = DamageCalculator.CalculateDamage(amount: 10, mitigationPercent: 0.8f);

        Assert.AreEqual(expected: 2, actual: finalDamage);
    }
}