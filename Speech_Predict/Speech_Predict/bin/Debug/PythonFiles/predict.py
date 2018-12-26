# -*- coding: utf-8 -*-
import abalone 
import numpy as np
import pandas as pd
# testdataSet= pd.read_csv(r"./baoyuData-test.csv",header=None)[0:1]
#preddataset=testdataSet.iloc[:,:-1]#测试数据集,除最后一列

# # print(preddataset.shape)
input="M,0.455,0.365,0.095,0.514,0.2245,0.101,0.15,15;M,0.35,0.265,0.09,0.2255,0.0995,0.0485,0.07,7"
ilist=input.split(";")
mlist=[item.split(',') for item in input.split(";")]
# print(mlist)
testdataSet=pd.DataFrame(np.mat(mlist))
# print (testdataSet)
theta=np.loadtxt("./params.txt")
#print (theta.shape)
rage=testdataSet.iloc[:,-1]#真实值
X,Y,ymin,ymax,age=abalone.HandleData(testdataSet)
age=(X.dot(theta))*(ymax-ymin)+ymin
ret=""
# for item in age.tolist():
# ret=''.join(age.tolist())+"\n"
print(age.tolist())
# print(rage)