# !/usr/bin/env python
# coding: utf-8
# Create your views here.
from django.shortcuts import render
from django.http import HttpResponse


import numpy as np

import pandas as pd
# import matplotlib.pyplot as plt
from numpy import genfromtxt

# testdataSet= pd.read_csv(dataPath,header=None).iloc[40:]


def HandleData(dataSet):
    sex = []

    length = []
    diameter = []
    height = []

    totalw = []
    skinw = []
    innerw = []
    shellw = []
    # 性别长度直径高度总重量皮重内脏重量壳重
    age = []
    sex = [1 if item == "M" else 0 if item == "F" else 2 for item in dataSet[:][0]]
    for i in range(0, len(dataSet)):
        length.append(dataSet.iloc[i, 1])  # error 1:
        diameter.append(dataSet.iloc[i, 2])
        height.append(dataSet.iloc[i, 3])

        totalw.append(dataSet.iloc[i, 4])
        skinw.append(dataSet.iloc[i, 5])
        innerw.append(dataSet.iloc[i, 6])
        shellw.append(dataSet.iloc[i, 7])

        age.append(dataSet.iloc[i, 8])
    # x1,x1min,x1max = Normalization(sex)
    x1 = np.array(sex)  # error 2

    x2, x2min, x2max = Normalization(length)
    x2 = np.array(x2)

    x3, x3min, x3max = Normalization(diameter)
    x3 = np.array(x3)
    x4, x4min, x4max = Normalization(height)
    x4 = np.array(x4)
    x5, x5min, x5max = Normalization(totalw)
    x5 = np.array(x5)
    x6, x6min, x6max = Normalization(skinw)
    x6 = np.array(x6)
    x7, x7min, x7max = Normalization(innerw)
    x7 = np.array(x7)
    x8, x8min, x8max = Normalization(shellw)
    x8 = np.array(x8)

    X = np.concatenate((x1[:, np.newaxis], x2[:, np.newaxis], x3[:, np.newaxis], x4[:, np.newaxis],
                        x5[:, np.newaxis], x6[:, np.newaxis], x7[:, np.newaxis], x8[:, np.newaxis]), axis=1)
    X = np.hstack([np.ones((X.shape[0], 1)), X])  # 添加首列为1的常数列
    #     print(age)
    # print("original trainage is:",age,max(age),min(age))

    y, ymin, ymax = Normalization(age)
    Y = np.array(y)[:, np.newaxis]  # n*1矩阵备用
    return X, Y, ymin, ymax,age

def Normalization(x):  # 数据预处理归一化
    x = [float(i) for i in x]
    Min = min(x)
    Max = max(x)

    return [(float(i) - Min) / float(Max - Min) for i in x], Min, Max

def gradientDescent(theta, x, y):  # 求解在当前theta下的loss和梯度
    num = x.shape[0]  # 多少行
    predict = x.dot(theta)
    error = predict - y
    loss = np.sum(np.square(error)) / num
    # print(loss)
    dtheta = np.dot(x.T, error) * 2 / num
    return loss, dtheta

def train(X, Y, learning_rate=1e-3, num_iters=100, batch_size=3):  # 训练函数，准备每次迭代数据，计算梯度并更新，记录损失变化
    num_train = X.shape[0]
    num_col = X.shape[1]
    theta = np.ones((num_col, 1))
    loss_history = []
    for it in range(num_iters):
        X_batch = None
        Y_batch = None
        # print("num_train",num_train)
        sample_index = np.random.choice(num_train, batch_size, replace=False)
        # print("X:",X)
        # print("sample_index",sample_index)
        X_batch = X[sample_index, :]  # 随机选择几行数据进行训练
        Y_batch = Y[sample_index]

        loss, grad = gradientDescent(theta, X_batch, Y_batch)  # dw
        loss_history.append(loss)
        theta = theta - grad * learning_rate
    return loss_history, theta
def hello(request):
    return  HttpResponse("Hello world")
def getTheta(request):
    dataPath = r"abalone/files/baoyuData.csv"
    dataSet = pd.read_csv(dataPath, header=None)
    try:
        X, Y, ymin, ymax,a= HandleData(dataSet)  # 获取归一化训练数据X Y
        loss_hist, theta = train(X, Y, learning_rate=0.03, num_iters=100, batch_size=20)
        np.savetxt("abalone/files/params.txt", theta)
    except IOError:
        return HttpResponse("保存文件失败，请检查文件是否存在")
    else:
        return HttpResponse("已获取训练参数，请查收~")
def predict(request):
    #input=str(request.POST["traindata"])
    #print("input:",input)
    input = "M,0.455,0.365,0.095,0.514,0.2245,0.101,0.15,15;M,0.35,0.265,0.09,0.2255,0.0995,0.0485,0.07,7"
    #input="M,0.455,0.365,0.095,0.514,0.245,0.101,0.15,15;M,0.35,0.265,0.09,0.2255,0.0995,0.0485,0.07,7;F,0.53,0.42,0.135,0.6770.2565,0.1415.0.21,9"
    mlist = [item.split(',') for item in input.split(";")]
    testdataSet = pd.DataFrame(np.mat(mlist))
    theta = np.loadtxt("abalone/files/params.txt")
    X, Y, ymin, ymax, age = HandleData(testdataSet)
    age = (X.dot(theta)) * (ymax - ymin) + ymin
    ret = ""
    # for item in age.tolist():
    age = [str(float('%.1f' %i)) for i in age.tolist()]
    for index,item in enumerate(age):
        ret += '第'+str(index+1)+'项预测值是' + item + ' \n\r'
    return HttpResponse(ret)