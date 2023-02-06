using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LitJson;

namespace AssemblyCSharp.Pk9rGetData
{
    public class Pk9rController
    {
        public static bool IsSaveDataMap;
        public static bool IsSaveDataItem;
        public static bool IsSaveDataSkill;

        public static void UpdateData()
        {
            Service.gI().updateMap();
            Service.gI().updateItem();
            Service.gI().updateSkill();
        }

        public static void SaveDataMap()
        {
            //string Datamap = "";
            //for (int i = 0; i < TileMap.mapNames.Length; i++)
            //{
            //    Datamap += i + ":" + TileMap.mapNames[i] + Environment.NewLine;
            //}
            //File.WriteAllText("DataMap.txt", Datamap);
            File.WriteAllText("DataMap.json", JsonMapper.ToJson(TileMap.mapNames));
            File.WriteAllText("DataNpc.json", JsonMapper.ToJson(Npc.arrNpcTemplate));
            File.WriteAllText("DataMob.json", JsonMapper.ToJson(Mob.arrMobTemplate));
            IsSaveDataMap = true;
        }

        public static void SaveDataItem()
        {
            string data = JsonMapper.ToJson(ItemTemplates.itemTemplates.h);
            //var dataObj = JsonMapper.ToObject(data);
            //string exportdata = "";
            //for(int i = 0;i < dataObj.Count;i++)
            //{
            //    exportdata += dataObj[i]["id"] + ":" + dataObj[i]["name"]  + Environment.NewLine;
            //}
            //File.WriteAllText("DataItem.txt", exportdata);
            File.WriteAllText("DataItem.json", data);
            IsSaveDataItem = true;
        }

        public static void SaveDataSkill()
        {
            File.WriteAllText("DataSkill.json", JsonMapper.ToJson(GameScr.nClasss));
            IsSaveDataSkill = true;
        }

        public static void CheckQuitGame()
        {
            if (IsSaveDataMap && IsSaveDataItem && IsSaveDataSkill)
            {
                Main.exit();
            }    
        }
    }
}
