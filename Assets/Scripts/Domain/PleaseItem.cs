using System.Collections.Generic;

public class PleaseItem
{
    
    public static Dictionary<int, Dictionary<int, CharacterIconInfo>> ItemNameList = new Dictionary<int, Dictionary<int, CharacterIconInfo>>()
        {
            {1, new Dictionary<int, CharacterIconInfo> {
                {1, new CharacterIconInfo("ONluklukAicon", "A")},
                { 2, new CharacterIconInfo("ONluklukEicon", "E")},
                {3, new CharacterIconInfo("ONluklukBicon", "B")},
                {4, new CharacterIconInfo("ONluklukCicon", "C")},
                {5, new CharacterIconInfo("ONluklukDicon", "D")},
                }
            },
            { 2, new Dictionary<int, CharacterIconInfo> {
                {1, new CharacterIconInfo("ONdieuleiconA", "A")},
                {2, new CharacterIconInfo("ONdieuleiconB", "B")},
                {3, new CharacterIconInfo("ONdieuleiconC", "C")},
                }
            },
            { 3, new Dictionary<int, CharacterIconInfo> {
                {1, new CharacterIconInfo("OngelpiciconA", "A")},
                {2, new CharacterIconInfo("OngelpiciconB", "B")},
                {3, new CharacterIconInfo("OngelpiciconC", "C")},
                {4, new CharacterIconInfo("OngelpiciconD", "D")},
                {5, new CharacterIconInfo("OngelpiciconE", "E")},
            }
            },
            { 4, new Dictionary<int, CharacterIconInfo> {
                {1, new CharacterIconInfo("ONsroniconA", "A")},
                {2, new CharacterIconInfo("ONsroniconB", "B")},
                {3, new CharacterIconInfo("ONsroniconC", "C")},
                {4, new CharacterIconInfo("ONsroniconD", "D")},
                {5, new CharacterIconInfo("ONsroniconE", "E")},
            } },
            { 5, new Dictionary<int, CharacterIconInfo> {
                {1, new CharacterIconInfo("ONpameliconA", "A")},
                {2, new CharacterIconInfo("ONpameliconB", "B")},
                {3, new CharacterIconInfo("ONpameliconC", "C")},
                {4, new CharacterIconInfo("ONpameliconE", "E")},
                {5, new CharacterIconInfo("ONpameliconF", "F")},
            } },
            { 6, new Dictionary<int, CharacterIconInfo> {
                {1, new CharacterIconInfo("ONghigliaiconA", "A")},
                {2, new CharacterIconInfo("ONghigliaiconB", "B") },
                {3, new CharacterIconInfo("ONghigliaiconC", "C") },
                {4, new CharacterIconInfo("ONghigliaiconD", "D") },
                {5, new CharacterIconInfo("ONghigliaiconE", "E") },
            } },
            { 7, new Dictionary<int, CharacterIconInfo> {
                {1, new CharacterIconInfo("ONghigliaiconA", "A")},
                {2, new CharacterIconInfo("ONghigliaiconB", "B") },
                {3, new CharacterIconInfo("ONghigliaiconC", "C") },
                {4, new CharacterIconInfo("ONghigliaiconE", "E") },
            } }
        };
    public static Dictionary<string, System.TimeSpan> PleaseTimeWaitGroupList = new Dictionary<string, System.TimeSpan>()
    {
        {"B", new System.TimeSpan(0, 1, 5)},
        {"C", new System.TimeSpan(0, 30, 5)},
        {"D", new System.TimeSpan(1, 0, 5)},
        {"E", new System.TimeSpan(3, 1, 5)},
        {"F", new System.TimeSpan(6, 1, 5)},
    };
}

public class CharacterIconInfo {
    public string IconName;
    public string DressTypeName;
    public CharacterIconInfo(string iconName,string dressTypeName) {
        this.IconName = iconName;
        this.DressTypeName = dressTypeName;
    }
}
