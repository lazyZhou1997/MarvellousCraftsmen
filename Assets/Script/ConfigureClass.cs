﻿using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 配置文件类
/// </summary>
public class ConfigureClass {

    #region 资源文件路径信息

    #region sydney

    public static string sydneyItemsPicturePath = "Resource\\picture\\ItemBar\\Sydney\\";//悉尼歌剧院的物品图片存储地址  
    public static string sydneyItemsPrefabPath = "Resource\\prefab\\Sydney\\Collider\\";//悉尼歌剧院的Prefab存储地址
    public static string item_boxPicturePath = "Resource\\picture\\item_box";//物品栏中表示物品为空的图片
    public static string sydneyStepPath = "Resource\\prefab\\Sydney\\Step\\";//悉尼歌剧院的拼图结果预设体地址

    #endregion
    #endregion

    #region 保存下一个要加载的场景名称

    public static string nextSceneName;

    #endregion
    #region 拼图步骤

    public static Dictionary<string,int> sydneyStep = new Dictionary<string, int>();//悉尼歌剧院拼图步骤

    #endregion

    #region 对话内容

    public static Dictionary<string, string[]> dialogs = new Dictionary<string, string[]>();

    #endregion

    //静态构造函数，完成必要的初始化
    static ConfigureClass()
    {
        #region Sydney拼图步骤初始化

        sydneyStep.Add("OperaHouseBase", 1);
        sydneyStep.Add("TheaterFirstFloor", 2);
        sydneyStep.Add("ConcertFirstFloor", 3);
        sydneyStep.Add("ConcertSecondFloor", 4);
        sydneyStep.Add("OperaMainHall", 5);
        sydneyStep.Add("TheaterTopShell", 6);
        sydneyStep.Add("TopShellOfConcertHall", 7);
        sydneyStep.Add("TheaterTopShell2", 8);
        sydneyStep.Add("TopShellOfConcertHall2", 9);
        sydneyStep.Add("RestaurantTopShell", 10);
        sydneyStep.Add("end", 10);

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
            ""
        };

        #endregion
    }
}