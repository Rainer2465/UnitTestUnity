using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;

public class character_with_inventory
{
    [Test]
    public void with_90_armor_takes_10_percent_damage()
    {
        ICharacter character = Substitute.For<ICharacter>();
        Inventory inventory = new Inventory(character);
        Item pants = new Item() { EquipSlot = EquipSlots.Legs, Armor = 40 };
        Item shield = new Item() { EquipSlot = EquipSlots.RightHand, Armor = 50 };

        inventory.EquipItem(pants);
        inventory.EquipItem(shield);

        character.Inventory.Returns(inventory);

        int calculatedDamage = DamageCalculator.CalculateDamage(amount: 1000, character);

        Assert.AreEqual(100, calculatedDamage);
    }
}
