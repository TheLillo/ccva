   M S B A M L   `   `   `  ���� F  BMRJoinerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MRJoinerWPFMRJoinerWPF      MRJoinerWPF.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:MRJoinerWPF       � Icon$  /Resources/icon.ico�� � Title$ MRJoiner��$	��350��$	��525�� � 
ResizeMode$ CanMinimize=� � WindowStartupLocation$ CenterScreen=�.��� .+��� -    ��Name$ 
tabControl��$
��Left=�$	��311��$	��Top=�$	��509��.@��� $��
Join Files��.��� ���	#FFE5E5E5.+��� -    ��Name$ label��$)��#Select the future container file...��$
��Left=�$��	10,10,0,0q�$	��Top=��� -    ��Name$ textFileToOverride��$
��Left=�$��23�� �� TextWrapping$
 Wrap=�$	��Top=�$	��410��$��	10,36,0,0q� �� 
IsReadOnly . "	 �� VerticalScrollBarVisibility$	 Disabled=�$
 �� HorizontalScrollBarVisibility$

 Auto=��� -    ��Name$ buttonFileToOverride��$	��...��$
��Left=�$��
442,36,0,0q�$	��Top=�$��28��$��23���� -   $ label1��$A��;Select the file(s) that will be joined to the first file...��$
��Left=�$	��Top=�$��	10,64,0,0q�$	��276���� -   $ textFileToZip��$
��Left=�$��23��$��	10,95,0,0q�$
 Wrap=�$	��Top=�$	��410�� . �� -   $ buttonFilesToZip��$	��...��$
��Left=�$��
442,95,0,0q�$	��Top=�$��28��$��23���� -    ��Name$ groupBox��$��Encrypt��$
��Left=�$��
10,123,0,0q�$	��Top=�$	��100��$	��214��.���� $
��Left=�$��80��$��10,10,0,-12q�$	��Top=�$	��192��.+�	� -	    	�Name$ noEnc�� 	� 	GroupName$ En��$
��None�� d� 	IsChecked$
 TrueY�	� -
   $ yesEnc��$ En��$��Encrypt�� J� RenderTransformOrigin$ 1.559,0.533&��� -    ��Name$ crypterListAlgorithm��$��0,0,6,0q�{�.  �� -   $ label2��$��Password��$
��Left=�$��229,134,0,0q�$	��Top=�G� -    G�Name$ textPass��$
��Left=�$��23��$��230,180,0,0q�$	��Top=�$	��241��{�.  �� -   $ textOutputFile��$
��Left=�$��23��$��
10,246,0,0q�$
 Wrap=�$	��Top=�$	��344�� . �� -   $ label3��$��Output File��$
��Left=�$��
10,220,0,0q�$	��Top=��� -   $ buttonStartJoin��$��Start��$
��Left=�$��395,246,0,0q�$	��Top=�$��75��� -    �Name$ progressEncrypt��$
��Left=�$��10��$��
84,231,0,0q�$	��Top=�$	��386���� $��	Open File��.��� ���	#FFE5E5E5.+��� -   $ label4��$$��Select the files to be open...��$
��Left=�$��	10,10,0,0q�$	��Top=��� -   $ textBoxOpenFile��$
��Left=�$��23��$��	10,36,0,0q�$
 Wrap=�$	��Top=�$	��410�� . �� -   $ buttonFileToOpen��$	��...��$
��Left=�$��
443,36,0,0q�$	��Top=�$��50��$��25���� -   $ buttonStartOpenFile��$��Start��$
��Left=�$��
418,80,0,0q�$	��Top=�$��75���� -   $ 	groupBox1��$��Decrypt��$
��Left=�$��
10,100,0,0q�$	��Top=�$	��183��$	��483��.���� $
��Left=�$	��163��$��10,0,-2,-12q�$	��Top=�$	��463��.+��� -   $ label5��$#��Select the crypted file(s)...��� $��25�� � 	Resources  �� 
TargetType �� Property �� Value��%/   '��       �� " ��.���  � ��$
 18,0q�.+��� -   $ textFileToDecrypt��$��23��$
 Wrap=�$	��377�� . �� -   $ buttonFileToDecrypt��$	��...��$��50��� $��28��.+��� -   $ label6��$#��Select Algorithm             ���� -   $ algorithmListDec��$	��170��� $��25��.+��� -   $ label7��$��Password��G� -   $ textPassDecrypt��$��23��$	��400��� $��25��.+��� -   $ label8��$��Output file...��� -   $ progressDecrypt��$��10��$	��362��� $��25�� ��%/   '��       �� " ��.���  � ��$
 18,0q�.+��� -    $ textOutFile��$��23��$
 Wrap=�$	��345�� . �� -!   $ buttonStartDecrypt��$��Start��$��75��� -"   $ progressBarWithoutDecrypt��$
��Left=�$��10��$��	10,85,0,0q�$	��Top=�$	��403��