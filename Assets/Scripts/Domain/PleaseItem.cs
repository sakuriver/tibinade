using System.Collections.Generic;

public class PleaseItem
{
    public static Dictionary<int, Dictionary<int, string>> ItemNameList = new Dictionary<int, Dictionary<int, string>>()
        {
            {1, new Dictionary<int, string> {
                {1, "ONluklukEicon"},
                {2, "ONluklukBicon"},
                {3, "ONluklukCicon"},
                {4, "ONluklukDicon"},
                }
            },
            { 2, new Dictionary<int, string> {
                {1, "ONdieuleiconA"},
                {2, "ONdieuleiconB"},
                {3, "ONdieuleiconC"},
                }
            },
            { 3, new Dictionary<int, string> {
                {1, "OngelpiciconB"},
                {2, "OngelpiciconC"},
                {3, "OngelpiciconD"},
                {4, "OngelpiciconE"},
            }
            },
            { 4, new Dictionary<int, string> {
                {1, "ONsroniconA"},
                {2, "ONsroniconB"},
                {3, "ONsroniconC"},
                {4, "ONsroniconD"},
                {5, "ONsroniconE"},
            } },
            { 5, new Dictionary<int, string> {
                {1, "ONpameliconA"},
                {2, "ONpameliconB"},
                {3, "ONpameliconC"},
                {4, "ONpameliconE"},
                {5, "ONpameliconF"},
            } },
            { 6, new Dictionary<int, string> {
                {1, "ONghigliaiconB" },
                {2, "ONghigliaiconC" },
                {3, "ONghigliaiconD" },
                {4, "ONghigliaiconE" },
            } }

        };
}