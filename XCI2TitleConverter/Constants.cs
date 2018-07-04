using System.Collections.Generic;
using System.IO;

namespace XCI2TitleConverter
{
    class Constants
    {
        public static string BACKUP_SUFFIX = ".bak";
        public static string CONFIG_FILE = "config.ini";
        public static IniFile config = new IniFile(Path.Combine(".", CONFIG_FILE));
        public static string TITLE_LIST_URL = "http://switchbrew.org/index.php?title=Title_list/Games";
        public static string BBB_RELEASES_URL = "http://nswdb.com/xml.php";
        public static Dictionary<string, string> TARGET_TITLES = new Dictionary<string, string>()
        {
            {"010025400AECE000", "Fortnite"},
            {"01005A70096FA000", "Kirby Star Allies Demo"},
            {"01002C400B6B6000", "Captain Toad: Treasure Tracker Demo"},
            {"010043500A17A000", "Fallout Shelter"},
            {"01008D00062C2000", "VOEZ Demo"},
            {"0100DB7003828000", "Pinball FX3"},
            {"010096000B3EA000", "Octopath Traveler Demo"},
            {"01000C900A136000", "Kitten Squad"},
            {"01005D100807A000", "Pokemon Quest"},
            {"0100AE0006474000", "Stern Pinball"},
            {"0100CD300880E000", "Pinball Arcade"},
            {"0100E65002BB8000", "Stardew Valley"},
            {"01000A10041EA000", "Skyrim"},
            {"0100000000010000", "Super Mario Odyssey"},
            {"01005EE0036EC000", "Rocket League"},
            {"0100152000022000", "Mario Kart 8 Deluxe"},
            {"01007EF00011E000", "The Legend of Zelda: Breath of the Wild"},
            {"0100A5400AC86000", "ARMS Demo"},
            {"0100BA3003B70000", "NAMCO MUSEUM PAC-MAN VS"},
            {"0100C360070F6000", "DRAGON QUEST BUILDERS Demo"},
            {"0100E67003A86000", "Disgaea 5 Complete Demo"},
            {"0100F5E008AA0000", "LOST SPHEAR Demo"},
            {"01004AF00A772000", "Monsters 2 Demo"},
            {"01004E300899E000", "Wanderjahr TryAgainOrWalkAway Demo"},
            {"01006E30099B8000", "Pic-a-Pix Deluxe Demo"},
            {"01006EE00AE38000", "Shining Resonance Refrain Demo"},
            {"010090B005150000", "Oceanhorn Demo"},
            {"010069700AF9C000", "Happy Birthdays DEMO"},
            {"0100DE700B028000", "Semispheres Demo"},
            {"0100E3500B00E000", "The Bridge Demo"},
            {"01005AE00A528000", "Star Ghost Demo"},
            {"01005B3005D6E000", "League Of Evil DEMO"},
            {"01007E6007764000", "Death Squared The Employee Evaluation Demo"},
            {"010007B009314000", "I and Me DEMO"},
            {"010045B00849C000", "MIGHTY GUNVOLT BURST DEMO"},
            {"010093E00ACB0000", "Kid Tripp Demo"},
            {"010039300A56C000", "Squareboy vs Bullies Arena Edition DEMO"},
            {"010044200A112000", "Vostok Inc Demo"},
            {"010045600A0D4000", "Quest of Dungeons DEMO"},
            {"010009100845A000", "INVERSUS Deluxe Demo"},
            {"0100917007888000", "Piczle Lines DX Demo"},
            {"0100A9A0088FE000", "Max The Curse Of Brotherhood Demo"},
            {"010086100AA54000", "Portal Knights Demo"},
            {"0100974004924000", "RAYMAN® LEGENDS: DEFINITIVE EDITION DEMO"},
            {"0100D87002EE0000", "Snipperclips – Cut it out, together! ™ Demo"},
            {"01000DC003740000", "Puyo Puyo Tetris Demo"},
            {"0100FA500B128000", "Sushi Striker The Way of Sushido Demo"},
        };
    }
}
