# 说明：
本项目后端由Django框架提供训练和预测接口，
前端沿用作业中语音实践的Winform窗口，提供训练以及预测入口和结果展示。

训练：使用作业中的梯度下降方法，没来的及更换使用paddle框架，数据预测上由于只使用线性函数，可能误差相对较大。
	 ，欢迎大家进行优化和改进。
	 
一、开发环境：
    pyablone--django后台服务  PYTHON-推荐配pycharm
	Speech_Predict             、c#-vs
	
二、操作步骤

1、启动django服务，在manage目录执行python manage.py runserver 8000
2、打开vs启动程序,运行生成form窗口,进行调试训练数据和预测操作。



