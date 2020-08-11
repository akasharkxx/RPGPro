using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStat
{
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += onEquipmentChanged;
    }

    void onEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if(newItem != null)
        {
            armor.AddModifiers(newItem.armorModifier);
            damage.AddModifiers(newItem.damageModifier);
        }

        if (oldItem != null)
        {
            armor.RemoveModifiers(oldItem.armorModifier);
            damage.RemoveModifiers(oldItem.damageModifier);
        }
        
    }

    public override void Die()
    {
        base.Die();
        PlayerManager.instance.KillPlayer();
    }
}
