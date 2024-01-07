## 记录环境设置以及工程步骤：
##### 一、场景基础设置

（1）下载图像合成框架<https://bitbucket.org/Unity-Technologies/ml-imagesynthesis/downloads/>

- 可以为场景中的每个对象根据类别分配颜色，捕捉深度/光流/法线等png信息

（2）将下载的文件导入Unity（我用的版本是**2021.3.26f1**）

（3）在新场景中创建一些3D物体，然后为他们设置不同的图层。并且为主摄像头添加imagesynthesis组件达到如test1_layer的渲染效果。为了方便后续添加相同的物体可以创建预制文件夹Prefabs（直接将想要预制的对象拖入即可）

（4）为了解决新加入的物体不能实时显示正确的渲染颜色的问题，创建scenecontroller脚本，并将此组件添加到场景中，并且将synth拾取main camera

![设置对齐方式](../ImageSynthesisLearning/ImageSynthPart1/Recordings/alignwithview.png)

（5）设置相机的分辨率为512*512。

##### 二、随机生成物体

（1）首先为预制对象成员都添加刚体属性，这样可以与地面（plane）发生碰撞

（2）写脚本控制随机对象的生成

- 设置位置/旋转/缩放/颜色

- 设置为每帧都创建新对象

- 由于销毁速度小于创建速度，导致内存不断增加(Window-Analysis-Profiler)，因此引入对象池

  ![内存问题](../ImageSynthesisLearning/ImageSynthPart1/Recordings/memoryproblem.png)