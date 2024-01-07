## 记录环境搭建以及工程步骤：
（1）下载图像合成框架<https://bitbucket.org/Unity-Technologies/ml-imagesynthesis/downloads/>

- 可以为场景中的每个对象根据类别分配颜色，捕捉深度/光流/法线等png信息

（2）将下载的文件导入Unity（我用的版本是**2021.3.26f1**）

（3）在新场景中创建一些3D物体，然后为他们设置不同的图层。并且为主摄像头添加imagesynthesis组件达到如test1_layer的渲染效果。为了方便后续添加相同的物体可以创建预制文件夹Prefabs（直接将想要预制的对象拖入即可）

（4）为了解决新加入的物体不能实时显示正确的渲染颜色的问题，创建scenecontroller脚本，并将此组件添加到场景中，并且将synth拾取main camera。

