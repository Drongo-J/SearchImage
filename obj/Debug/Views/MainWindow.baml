   M S B A M L   `   `   `  ����F  BSearchImage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SearchImage.ViewsSearchImage.Views  5   	   "    SearchImage.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:SearchImage.Views     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  67     � Title$  Search Image��5   	    � Icon$ \Images\image.ico��5	   	    � 
ResizeMode$ CanMinimize=�5
   	   $	��650��5   	    � WindowStartupLocation$ CenterScreen=�5   	   $
��1100��5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��1.5* �6   6,   �� 5      $��8* �6   6*   .+�5   
   � $��0��6   .+�5      �� 
������ $
��Auto��5      $
��1500��5      .+�5      �� -   5        $��SearchTB��5         MyTextBoxStyle#��[  5      $��46��5      $��	15,5,35,0q�5      $��27(�5      
�������$��Cascadia Code SemiBold)�5      $��Search For Image . . .��5       �� Left$ 80��5       
 �� Top$ 28��5!      $
��Left=�5"      $	��Top=�5#      $	��875��5$      .��6&    J� InputBindings 5%      �� 5&      
 �� Key$ Return��6%   	 �� Command	 62   �� *SearchCommand+6V   .��5'   -   *  $Microsoft.Xaml.Behaviors.Interaction
   Triggers
 5(      +  %Microsoft.Xaml.Behaviors.EventTrigger  5)         	EventName$ 
MouseEnter��6)   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5*      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 64   �� *MouseEnterCommand+5+        5-      $ 
MouseLeave��6)   . 5.         64   �� *MouseLeaveCommand+5/        51      $ GotFocus��6)   . 52         64   �� *IsFocusedCommand+53        55      $ 	LostFocus��6)   . 56         64   �� *IsNotFocusedCommand+57      .��58   .   59      �� 5;      $��\Images\clear.png��6    � Cursor$
 Hand��5<      $��23��5=      $��20��5>      $	 925��5?      $ 39��5@      $
��Left=�5A      $��Center=�5B       J� RenderTransformOrigin$ 3.3,0.6&�5C       5D      d� 5E       d� Gesture$ 	LeftClicka�6'   	 6;   �� *ClearCommand+6^   5G      �� 5I        MyButtonStyle#��[ 6    �� Right$	 400��5J      $��46��5K      $ 28��5L      $��33(�5M      $��Cascadia Code SemiBold)�5N      $��Normal"�5O      $
 Hand��5P      $��55��5R      $	 955��5S      $
��Left=�5T      ��5Q      �� *SearchCommand+5T      �� 5U      $��\Images\Search.png��6   $��32��5V      $��32��5W      $	 400��5X      $ 36��5Y      $
 Hand��5Z      $��Center=�5[      $	��Top=�5\      $	 963��5]       5^      d� 5_      $ 	LeftClicka�6'   	 6;   �� *SearchCommand+6_   5a      5b      5c      � 5e   
   $��1��6   .+�5f      �� 
������   LvItemStyle#��[ 5h      $��	105,0,0,0q�6I   ��5f      �� *Images+��5i      �� 5j      .R�5k      � $
��Auto��6$   $
��1100��5l   $   $��0,20,0,0q�5m   $   5n      5o      5q      5r      5s      5t      