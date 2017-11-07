using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 配置文件类
/// </summary>
public class ConfigureClass {

    #region 资源文件路径信息

    public static Dictionary<string, string> itemsPicturePath = new Dictionary<string, string>();//存储所有物品图片路径信息，key为场景，值为路径
    public static Dictionary<string, string> itemsPrefabPath = new Dictionary<string, string>();//存储所有物品Prefab路径信息，key为场景，值为路径
    public static Dictionary<string, string> stepPath = new Dictionary<string, string>();//存储拼图结果预设体地址，key为场景，值为路径


    public static string item_boxPicturePath = "Resource\\picture\\item_box";//物品栏中表示物品为空的图片

    #endregion

    #region 保存下一个要加载的场景名称

    public static string nextSceneName;

    #endregion
    #region 拼图步骤

    public static Dictionary<string,int> puzzleStep = new Dictionary<string, int>();//悉尼歌剧院拼图步骤

    #endregion

    #region 对话内容

    public static Dictionary<string, string[]> dialogs = new Dictionary<string, string[]>();

    #endregion
    
    #region 模型介绍

    public static Dictionary<string,string> descriptions=new Dictionary<string, string>();

    #endregion

    //静态构造函数，完成必要的初始化
    static ConfigureClass()
    {
        #region Sydney拼图步骤初始化

        puzzleStep.Add("OperaHouseBase", 1);
        puzzleStep.Add("TheaterFirstFloor", 2);
        puzzleStep.Add("ConcertFirstFloor", 3);
        puzzleStep.Add("ConcertSecondFloor", 4);
        puzzleStep.Add("OperaMainHall", 5);
        puzzleStep.Add("TheaterTopShell", 6);
        puzzleStep.Add("TopShellOfConcertHall", 7);
        puzzleStep.Add("TheaterTopShell2", 8);
        puzzleStep.Add("TopShellOfConcertHall2", 9);
        puzzleStep.Add("RestaurantTopShell", 10);
        puzzleStep.Add("sydney", 10);//拼图结束

        #endregion

        #region Cabins拼图步骤初始化

        puzzleStep.Add("Base", 1);
        puzzleStep.Add("FrontWall", 2);
        puzzleStep.Add("BackWall", 3);
        puzzleStep.Add("SideWall", 4);
        puzzleStep.Add("InnerWall", 5);
        puzzleStep.Add("Window", 6);
        puzzleStep.Add("Door", 7);
        puzzleStep.Add("Beam", 8);
        puzzleStep.Add("Roof", 9);
        puzzleStep.Add("cabins", 9);//拼图结束

        #endregion

        #region Library拼图步骤初始化

        puzzleStep.Add("SideRoom", 1);
        puzzleStep.Add("SideRoof", 2);
        puzzleStep.Add("TheLongCorridor", 3);
        puzzleStep.Add("PromenadeRoof", 4);
        puzzleStep.Add("TheMainHall", 5);
        puzzleStep.Add("RoofOfMainBuilding", 6);
        puzzleStep.Add("SideHall", 7);
        puzzleStep.Add("library", 7);//拼图结束

        #endregion

        #region SailBoat拼图步骤初始化

        puzzleStep.Add("Bottom", 1);
        puzzleStep.Add("Bone", 2);
        puzzleStep.Add("Board", 3);
        puzzleStep.Add("FrontSail", 4);
        puzzleStep.Add("MiddleSail", 5);
        puzzleStep.Add("BackSail", 6);
        puzzleStep.Add("sailboat", 6);//拼图结束

		#endregion

        #region Jeep拼图步骤初始化

        puzzleStep.Add("CarBase", 1);
        puzzleStep.Add("Wheel", 2);
        puzzleStep.Add("Engine", 3);
        puzzleStep.Add("Seat", 4);
        puzzleStep.Add("CarShell", 5);
        puzzleStep.Add("FrontDoor", 6);
        puzzleStep.Add("BackDoor", 7);
        puzzleStep.Add("jeep", 7);//拼图结束

        #endregion

        #region Bicycle拼图步骤初始化

        puzzleStep.Add("BikeFrame", 1);
        puzzleStep.Add("HandleBar", 2);
        puzzleStep.Add("Saddle", 3);
        puzzleStep.Add("BackPivot", 4);
        puzzleStep.Add("BrakeDisc", 5);
        puzzleStep.Add("Chain", 6);
        puzzleStep.Add("FootBoard", 7);
        puzzleStep.Add("FrontFork", 8);
        puzzleStep.Add("FrontPivot", 9);
        puzzleStep.Add("BikeWheel", 10);
        puzzleStep.Add("bicycle", 10);//拼图结束

		#endregion

		#region Carousel拼图步骤初始化

		puzzleStep.Add("LandBase", 1);
		puzzleStep.Add("MiddleColumn", 2);
		puzzleStep.Add("HorseDOWN", 3);
		puzzleStep.Add("HorseUP", 4);
		puzzleStep.Add("RoofDecoration", 5);
		puzzleStep.Add("Orbit", 6);
		puzzleStep.Add("Umbrella", 7);
        puzzleStep.Add("carousel", 7);//拼图结束

		#endregion

		#region 初始化对话内容

		string[] oneDialog;
        //加载悉尼歌剧院对话
        oneDialog = new[]
        {
            "奇奇：村长，这就是我上次给你提到的歌剧院的设计图",
            "村长：哦。。。长这个样子啊，这是用来听音乐的？",
            "奇奇：对，这里面有一个舞台，还有很多座位，里面有相关的设备，建好之后可以在台上表演，然后台下的观众可以欣赏音乐和表演。",
            "村长：听起来挺好的，那还要麻烦你们啦。"
        };
        dialogs.Add("sydney",oneDialog);

        //加载小木屋对话
        oneDialog = new[]
        {
            "奇奇：“你好，我们是来自地球的一支星际旅行队，因为飞船故障被迫降落在这里。。”",
            "奇奇：“请问我们可以在这里短暂休整一段时间，然后再继续出发吗？”",
            "村长：“。。。地球，是个什么样的地方？我们这里的人，从来没有听说过。”",
            "奇奇：“地球是太阳系八大行星之一，按离太阳由近及远的次序排为第三颗，也是太阳系中直径、质量和密度最大的类地行星，距离太阳1.5亿公里。地球自西向东自转，同时围绕太阳公转。现有40~46亿岁，它有一个天然卫星——月球，二者组成一个天体系统——地月系统。46亿年以前起源于原始太阳星云。”",
            "村长：“听起来很复杂，但是好像是个好地方。”",
            "奇奇：“这是官方定义。。但是地球确实是一个适宜长久居住的好地方哦。”",
            "村长：“等我和村民们商量一下。”",
            "村长：“大家都对地球很好奇，也很愿意为你们提供帮助。要想在这里生活总要有自己的屋子吧，我们的房子可不够你们这么多人住，这里有一张我们住的木屋的图纸，我们前几天才从后面伐了一批木材，可以提供给你们。”",
            "奇奇：“真的非常感谢你们！”"
        };
        dialogs.Add("cabins",oneDialog);
        
        //加载图书馆对话
        oneDialog = new[]
        {
            "奇奇：“你好，请问你是这里的老师吗？”",
            "教师：“啊，是的，我负责在这里给孩子们上课。”",
            "奇奇：“教室可真整齐，孩子们也很听话的样子。”",
            "教师（露出欣慰的笑容）：“是啊，他们都很听话，可惜我们这个小地方，能看的书也没有几本，接触的东西也少。”",
            "奇奇：“说到这个，我倒有个提议。”",
            "教师：“请说。”",
            "奇奇：“我想为孩子们建造一座图书馆，平时孩子们可以在里面读书学习，我们队伍讨论过这个事情，也画好了一张设计图，如果你们同意，我们马上就可以开工。”",
            "教师：“啊。。这个提议很棒！”"

        };
        dialogs.Add("library",oneDialog);

        //加载帆船对话
        oneDialog = new[]
        {
            "奇奇：“非常感谢您，也感谢大家这段时间的帮助，如果没有你们，我们的旅行将很难进行下去。”",
            "村长：“哪里的话，你们也给我们的小岛带来了很多的变化。这是一份小礼物，也许对你们接下来的航行有帮助。”",
            "（礼物是用于登上大陆的卷轴）",
            "奇奇：“非常感谢您！后会有期！”",
            "村长：“一路平安，后会有期。”"

        };
        dialogs.Add("sailboat",oneDialog);

        //加载自行车对话
        oneDialog = new[]
        {
            "奇奇：“现在的当务之急就是要寻找重建飞船的线索，这个地方这么大，好像跑来跑去比较耽误时间。”",
            "居民：“我们这里倒是会提供免费的自行车，就是它们散落在各个地方，而且随时可能会被其他人骑走。要不你们去自行车行看看有没有合意的吧。”",
            "奇奇：“啊，既然如此那我们自己组装一辆自行车吧！自己动手丰衣足食嘛。”",
            "居民：“很有道理。我帮你们找需要的材料吧。”",
            "奇奇：“非常感谢。”"

        };
        dialogs.Add("bicycle",oneDialog);
        
        //加载吉普车对话
        oneDialog = new[]
        {
            "居民：“你们上次的自行车使用体验还好吗？”",
            "奇奇：“挺好的，感觉做的很成功。”",
            "居民：“是这样，最近部队想运输一批物资，但是吉普车数量不够了，听说你们要出发寻找飞船材料，可不可以帮我们也找一找制造吉普车的材料呢？”",
            "奇奇：“没问题，交给我们吧。”"

        };
        dialogs.Add("jeep",oneDialog);
        
        //加载旋转木马对话
        oneDialog = new[]
        {
            "奇奇：“相别多日，这里一切还好吗？”",
            "村长：“感谢你们上次的帮助，现在大家的娱乐休闲活动比以前更多了，真的非常感谢你们。”",
            "奇奇：“这也是为了报答村长你们在我们需要帮助的时候收留了我们。这次来我们也准备了一个新的礼物想要送给村子呢。”"

        };
        dialogs.Add("carousel",oneDialog);

        #endregion
        
        #region 模型介绍

        string itemDescription;

        //加载悉尼歌剧院的介绍
        itemDescription ="悉尼歌剧院是一个地球上的著名建筑，歌剧或者其它形式的行为艺术在其中进行表演。世界各地均有歌剧院，且具有各自不同的建筑风格。";

        descriptions.Add("sydney",itemDescription);

        //加载小木屋介绍
        itemDescription="房屋是住人或存放东西的建筑物。房屋是家庭的基体，在这里人们可以避开外界一切干扰，和自己的亲人享受自由自在的生活。人们都为拥有自己的房屋而努力。";
        descriptions.Add("cabins",itemDescription);

        //加载图书馆介绍
        itemDescription="图书馆，是搜集、整理、收藏图书资料以供人阅览、参考的机构，早在公元前3000年就出现了图书馆，图书馆有保存人类文化遗产、参与社会教育等职能。";
        descriptions.Add("library",itemDescription);

        //加载帆船介绍
        itemDescription="船指的是：举凡利用水的浮力，依靠人力、风帆、发动机（如蒸气机、燃气涡轮、柴油引擎、核子动力机组）等动力,使能在水上移动的交通运输工具。";
        descriptions.Add("sailboat",itemDescription);

        //加载自行车介绍
        itemDescription="自行车，又称脚踏车或单车，通常是二轮的小型陆上车辆。人骑上车后，以脚踩踏板为动力，是绿色环保的交通工具。";
        descriptions.Add("bicycle",itemDescription);

        //加载吉普车介绍
        itemDescription="吉普车是越野车的一种，是四轮驱动，稳定性良好的车型。越野车有军用民用两种，作为军用是最普遍的。另外还有越野地质探矿车、民用越野敞蓬车等。";
        descriptions.Add("jeep",itemDescription);

        //加载旋转木马介绍
        itemDescription="旋转木马或回转木马游乐场机动游戏的一种，即旋转大平台上有装饰成木马且上下移动的座位供游客乘坐。如今在各大小游戏场、商场等地方皆有各式旋转木马。";
        descriptions.Add("carousel",itemDescription);
        
        #endregion

        #region 初始化所有物品图片路径信息

        itemsPicturePath.Add("sydney", "Resource\\picture\\ItemBar\\Sydney\\");//悉尼歌剧院
        itemsPicturePath.Add("cabins", "Resource\\picture\\ItemBar\\Cabins\\");//木屋
        itemsPicturePath.Add("library", "Resource\\picture\\ItemBar\\Library\\");//图书馆
        itemsPicturePath.Add("sailboat", "Resource\\picture\\ItemBar\\Sailboat\\");//帆船
        itemsPicturePath.Add("jeep", "Resource\\picture\\ItemBar\\Jeep\\");//越野车
        itemsPicturePath.Add("bicycle", "Resource\\picture\\ItemBar\\Bicycle\\");//自行车
        itemsPicturePath.Add("carousel", "Resource\\picture\\ItemBar\\Carousel\\");//旋转木马

        #endregion

        #region 初始化所有物品Prefab路径信息

        itemsPrefabPath.Add("sydney", "Resource\\prefab\\Sydney\\Collider\\");//悉尼歌剧院
        itemsPrefabPath.Add("cabins", "Resource\\prefab\\Cabins\\Collider\\");//木屋
        itemsPrefabPath.Add("library", "Resource\\prefab\\Library\\Collider\\");//图书馆
        itemsPrefabPath.Add("sailboat", "Resource\\prefab\\Sailboat\\Collider\\");//帆船
        itemsPrefabPath.Add("jeep", "Resource\\prefab\\Jeep\\Collider\\");//越野车
        itemsPrefabPath.Add("bicycle", "Resource\\prefab\\Bicycle\\Collider\\");//自行车
        itemsPrefabPath.Add("carousel", "Resource\\prefab\\Carousel\\Collider\\");//旋转木马

        #endregion

        #region 初始化拼图结果预设体地址

        stepPath.Add("sydney", "Resource\\prefab\\Sydney\\Step\\");//悉尼歌剧院
        stepPath.Add("cabins", "Resource\\prefab\\Cabins\\Step\\");//木屋
        stepPath.Add("library", "Resource\\prefab\\Library\\Step\\");//图书馆
        stepPath.Add("sailboat", "Resource\\prefab\\Sailboat\\Step\\");//帆船
        stepPath.Add("jeep", "Resource\\prefab\\Jeep\\Step\\");//越野车
        stepPath.Add("bicycle", "Resource\\prefab\\Bicycle\\Step\\");//自行车
        stepPath.Add("carousel", "Resource\\prefab\\Carousel\\Step\\");//旋转木马

        #endregion
    }

}
