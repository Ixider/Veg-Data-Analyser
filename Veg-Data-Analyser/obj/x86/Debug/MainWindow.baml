   M S B A M L   `   `   `  ����L  HVeg-Data-Analyser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Veg_Data_AnalyserVeg_Data_Analyser  5   	   "    Veg_Data_Analyser.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1localclr-namespace:Veg_Data_Analyser     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     67   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6t   -   5          � Title$  Veg Data Analyser��5   	   $	��682��6#   $
��1378��60    � 
ResizeMode$ NoResize=�6=    � WindowStartupLocation$ CenterScreen=�6S    � 	Resources 5         taskViewSource��%   &	        �� 5   
   6   5      .��5	      �  � DataContext# [  6   ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    � MappingMode$ RelativeToBoundingBox=�63    �� 
StartPoint$ 0.5,0&�6W   .��5      �  � Color$ 	#FFB0CEDC��6   	 � Offset$	 1Q�61   � 5      $ White��6   5      .+�5   
   �� -   5        
 ��Name$
 importButton��5      $��Import Data��6'   $
��Left=�6=   $��
10,588,0,0q�6X   $	��Top=�6l   $	��123��6�   $
��Bold"�6�   $��25��6�   
�������6�   �� 5   
   -   5        $
 	ClearData��5      $��
Clear Data��6$   $
��Left=�69   $��
10,618,0,0q�6T   $	��Top=�6h   $	��123��6�    J� RenderTransformOrigin$ 
0.48,22.45&�6�   $
��Bold"�6�   $��25��6�   
���  ��$��Verdana)�6�   
�������6  �� 5   
   -   5        $
 needsNoticeButton��5      $��Assesment and no Notice��6,   $
��Left=�6N   $��	10,48,0,0q�6i   $	��Top=�6|   $	��201��6�   $��33��6�   
�������6�   �� 5   
   -   5        $
 clearFiltersButton��5      $��Clear Filters��6-   $
��Left=�6E   $��	10,10,0,0q�6`   $	��Top=�6s   $	��100��6�   $ -1.977,2.15&�6�   $��33��6�   
����������	#FF049331$��2q�6  &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ taskDataGrid��5         AutoGenerateColumns .     EnableRowVirtualization . $��327,13,10,13q�6|      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�      
IsReadOnly . ��6d   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        idColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Id��5   N      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Id+6Z     5      -   5        task_numberColumn��$ Task No.��5   `   $ * 6r    6@   �� *task_number+6r   4  .System.Windows.Controls.DataGridTemplateColumn  5      -	   5        assessment_dateColumn��$ Assessment Date��5   H   $ * 6a      CellTemplate 5      �� 5      .R�5      (  "System.Windows.Controls.DatePicker  |�.     IsDropDownOpen .  {�.     SelectedDate 6;   �� *assessment_date+ �� Mode$ OneWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6�   5      5         5!      -
   5        assesmentColumn��$ 	Assesment��5!   \   $ * 6o    6>   �� *	assesment+6o     5"      -   5        fellortrimColumn��$ Fell or Trim��5"   ^   $ * 6t    6?   �� *
fellortrim+6t     5#      -   5        inspectionColumn��$ 
Inspection��5#   ^   $ * 6r    6?   �� *
inspection+6r     5$      -   5        noticeColumn��$ Notice��5$   V   $ * 6f    6;   �� *notice+6f     5%      -   5        meters_exposedColumn��$ Meters Exposed��5%   f   $ * 6~    6C   �� *meters_exposed+6~     5&      -   5        task_progressColumn��$ Task Progress��5&   d   $ * 6{    6B   �� *task_progress+6{   5(      �� 5)   
   -   5         ��Name$ OpenCheckBox��5)      $
��Open��6)   $
��Left=�68   $��
228,78,0,0q�6S   $	��Top=�6g    d� 	IsChecked$
 TrueY�6�   6�   �� 5*   
   -   5        $ InProgressCheckBox��5*      $��In Progress��6/   $
��Left=�6E   $��
228,98,0,0q�6`   $	��Top=�6t   $
 TrueY�6�   6�   �� 5+   
   -   5        $ CancelledCheckBox��5+      $��	Cancelled��6.   $
��Left=�6B   $��228,118,0,0q�6]   $	��Top=�6r   $
 TrueY�6�   6�   �� 5,   
   -   5        $ OnHoldCheckBox��5,      $��On Hold��6+   $
��Left=�6=   $��228,158,0,0q�6X   $	��Top=�6m   $ 0.5,0.5&�6�   $
 TrueY�6�   6�   �� 5-   
   -   5        $ ClosedCheckBox��5-      $��Closed��6+   $
��Left=�6<   $��228,138,0,0q�6W   $	��Top=�6l   $ 	0.169,0.4&�6�   $
 TrueY�6�   6�   �� 5.   
   
���   �$��1q�6%   $
��Left=�69   $	��137��6T   $��
216,50,0,0q�6a   $	��Top=�6u   $	��100��6�   ._�5/      �� $��Task Status
��6   $��	0,0,0,109q�64   $
��Bold"�6G   50      �� 51   
   $��Total Tasks :��6   $
��Left=�6(   $��
169,13,0,0q�6C   $	��Top=�6W   $
��Bold"�6o   �� 52   
   -   5         ��Name$ 
totalLabel��52      $��0��6$   $
��Left=�60   $��
251,13,0,0q�6K   $	��Top=�6_   $
��Bold"�6w   �� 53   
   -   5        $
 hasNoticeButton��53      $��Assesment and has Notice��6*   $
��Left=�6M   $��	10,86,0,0q�6h   $	��Top=�6{   $	��201��6�   $��33��6�   
�������6�   57      58      