   M S B A M L   `   `   `  ����K  GCifradoSimetrico, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CifradoSimetricoCifradoSimetrico  5   	   !    CifradoSimetrico.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CifradoSimetrico     5   	     � Title$  Demo distribution system��5   	   $	��400��6*   $	��600��67   ���	#FFFF7F27 � WindowStartupLocation$ CenterScreen=�6Z    � WindowStyle$ ThreeDBorderWindow=�6    � Icon$ 	/Icon.png��6�   $��Right=�6�   $	��Top=�6�    � 
ResizeMode$ NoResize=�6�   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��0* �6   �� 5      ��5   
   �� 5       �� ImageSource$ /Background.png��6    j� Stretch$ UniformToFill=�67   .+�5   
   �� -   5         ��Name$ InputFileText��5      $
��Left=�6)   $��
355,89,0,0q�6D   $	��Top=�6X   $��95��6p   $��2��6{   �� 5   
   -   5        	 ��Name$	 InputFileButton��5      $��	Select...��6*   $
��Left=�6>   $��
455,87,0,0q�6Y   $	��Top=�6m   $��83��6�   
�������$��2��6�   6�   �� 5   
   -   5        
 ��Name$
 InputFileLabel��5      $��
Input file��6(   $
��Left=�6=   $��
355,58,0,0q�6X   $	��Top=�6l   $
��Bold"�6�   $��16(�6�   $��2��6�   	� 5   
   -   5         	�Name$ OperationEncrypt��5      $��Encrypt��60   $
��Left=�6B   $��365,200,0,0q�6]   $	��Top=�6r   $��2��6�    d� 	IsChecked$
 TrueY�6�    	� 	GroupName$ 	Operation��6�   �� 5   
   -   5        $
 OutputFileLabel��5      $��Output file��6)   $
��Left=�6?   $��355,113,0,0q�6Z   $	��Top=�6o   $
��Bold"�6�   $��16(�6�   $��2��6�   �� 5   
   -   5        $ OutputFileText��5      $
��Left=�6*   $��355,144,0,0q�6E   $	��Top=�6Z   $��95��6r   $��2��6}   �� 5   
   -   5        $	 OutputFileButton��5      $��	Select...��6+   $
��Left=�6?   $��455,144,0,0q�6Z   $	��Top=�6o   $��83��6�   
�������$��2��6�   6�   	� 5   
   -   5        $ DecryptRadioButton��5      $��Decrypt��62   $
��Left=�6D   $��455,200,0,0q�6_   $	��Top=�6t   $��2��6�   $ 	Operation��6�   �� 5   
   -	   5        $
 OperationLabel��5      $��	Operation��6(   $
��Left=�6<   $��355,168,0,0q�6W   $	��Top=�6l   $
��Bold"�6�   $��16(�6�   $��2��6�   �� 5   
   -
   5        $	 GoButton��5      $��Go��6#   $
��Left=�60   $��355,304,0,0q�6K   $	��Top=�6`   $��28��6x   $	��183��6�   
�������$��2��6�   6�   �� 5   
   -   5        $ KeyText��5      $
��Left=�6#   $��
355,35,0,0q�6>   $	��Top=�6R   $	��183��6j   $��2��6v   �� 5   
   -   5        $
 KeyLabel��5      $	��Key��6"   $
��Left=�60   $��	355,4,0,0q�6K   $	��Top=�6^   $
��Bold"�6v   $��16(�6�   $��2��6�   �� 5   
   -   5        $
 AlgorithmLabel��5      $��	Algorithm��6(   $
��Left=�6<   $��351,228,0,0q�6W   $	��Top=�6l   $
��Bold"�6�   $��16(�6�   $��2��6�   �� 5   
   -   5         ��Name$ AlgorithmCombobox��5      $��2��6.   $
��Left=�6B   $��355,260,0,0q�6]   $	��Top=�6r   $	��183��6�    �� SelectedIndex$ 0��6�   .@�5      �� $	��DES��6   �� 5       $��AES-128��6   �� 5!      $��AES-192��6   �� 5"      $��AES-256��6   �� 5#      $��Custom��6   5$      �� 5%   
   -   5        $	 
Stop_Music��5%      $��
Stop Music��6%   $��2��6:   $��	38,29,0,0q�6N   
������� J� RenderTransformOrigin$ 0.655,-3.04&�6�   $��90��6�   $
��Left=�6�   $	��Top=�6�   5'      5(      