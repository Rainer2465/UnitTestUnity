using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;

public class inventory
{
    [Test]
    public void only_allows_one_chest_to_be_equipped_at_a_time()
    {
        ICharacter character = Substitute.For<ICharacter>();
        Inventory inventory = new Inventory(character);
        Item chestOne = new Item() { EquipSlot = EquipSlots.Chest };
        Item chestTwo = new Item() { EquipSlot = EquipSlots.Chest };

        inventory.EquipItem(chestOne);
        inventory.EquipItem(chestTwo);

        Item equippedItem = inventory.GetItem(equipSlot: EquipSlots.Chest);
        Assert.AreEqual(chestTwo, equippedItem); 
    }

    [Test]
    public void tells_character_when_an_item_is_equipped_successfully()
    {
        ICharacter character = Substitute.For<ICharacter>();
        Inventory inventory = new Inventory(character);
        Item chestOne = new Item() { EquipSlot = EquipSlots.Chest };

        inventory.EquipItem(chestOne);

        character.Received().OnItemEquipped(chestOne); 
    }
}
