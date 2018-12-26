
import numpy as np
import pandas as pd
# import matplotlib.pyplot as plt
from numpy import genfromtxt
import abalone
def HandleData(dataSet):
    sex=[]

    length=[]
    diameter=[]
    height=[]

    totalw = []
    skinw = []
    innerw = []
    shellw=[]
    #性别长度直径高度总重量皮重内脏重量壳重
    age=[]
    sex=[1 if item =="M" else 0 if item=="F" else 2 for item in dataSet[:][0]]
    print(sex)
    for i in range(0,len(dataSet)):

        length.append(dataSet.iloc[i,1])#error 1:
        diameter.append(dataSet.iloc[i,2])
        height.append(dataSet.iloc[i,3])

        totalw.append(dataSet.iloc[i,4])
        skinw.append(dataSet.iloc[i,5])
        innerw.append(dataSet.iloc[i,6])
        shellw.append(dataSet.iloc[i,7])
        
        age.append(dataSet.iloc[i,8])
    x1,x1min,x1max = Normalization(sex)
    x1 = np.array(x1)#error 2

    x2,x2min,x2max = Normalization(length)
    x2 = np.array(x2)

    x3,x3min,x3max = Normalization(diameter)
    x3 = np.array(x3)
    x4,x4min,x4max = Normalization(height)
    x4 = np.array(x4)
    x5,x5min,x5max = Normalization(totalw)
    x5 = np.array(x5)
    x6,x6min,x6max = Normalization(skinw)
    x6 = np.array(x6)
    x7,x7min,x7max = Normalization(innerw)
    x7 = np.array(x7)
    x8,x8min,x8max = Normalization(shellw)
    x8 = np.array(x8)

    X = np.concatenate((x1[:,np.newaxis], x2[:,np.newaxis],x3[:,np.newaxis],x4[:,np.newaxis],x5[:,np.newaxis],x6[:,np.newaxis],x7[:,np.newaxis],x8[:,np.newaxis]),axis = 1)
    X = np.hstack([np.ones((X.shape[0], 1)), X]) #添加首列为1的常数列
#     print(age)
    #print("original trainage is:",age,max(age),min(age))
    
    y,ymin,ymax = Normalization(age)
    Y = np.array(y)[:,np.newaxis]#n*1矩阵备用
    return X,Y,ymin,ymax,age
def Normalization(x): #数据预处理归一化
    Min = min(x)
    Max = max(x)
    return [(float(i)-Min)/float(Max-Min) for i in x], Min, Max
if __name__=='__main__':
    testdataSet= pd.read_csv(r"./baoyuData-test.csv",header=None)[0:1]
    X,Y,ymin,ymax,age=HandleData(testdataSet)