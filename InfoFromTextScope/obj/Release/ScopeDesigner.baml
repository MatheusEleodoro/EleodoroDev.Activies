   M S B A M L   `   `   `  ���� e  aSystem.Activities.Presentation, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35wTclr-namespace:System.Activities.Presentation;assembly=System.Activities.PresentationSystem.Activities.Presentation  �_clr-namespace:System.Activities.Presentation.Converters;assembly=System.Activities.Presentation)System.Activities.Presentation.Converters  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  InfoFromTextScope%   InfoFromTextScope.ScopeDesigner   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     dsapTclr-namespace:System.Activities.Presentation;assembly=System.Activities.Presentation     psapc_clr-namespace:System.Activities.Presentation.Converters;assembly=System.Activities.Presentation     OsapvDhttp://schemas.microsoft.com/netfx/2009/xaml/activities/presentation   .s&clr-namespace:System;assembly=mscorlib     � 	Resources  M   GSystem.Activities.Presentation.Converters.ArgumentToExpressionConverter !  ArgumentToExpressionConverter  WorkflowItemsPresenterStyle �� 
TargetType;   5System.Activities.Presentation.WorkflowItemsPresenter �� Property �� Value �� Stretch J� RenderTransformOrigin �� Orientation��%r  &	        &	        �� "  .���  �@ SpacerTemplate �� .R��� 
������ ._�F� �����h_�
h��
���
P0�
�(��
xe�
� �P�N	� �0�襣
��	��.
P��	�(,
�X�	Ѹи	��	� �Eh3� �E��R	�x��	h��
�@�-
xo:�h_�
h��
$ Uniform=����	#FFDEDDDD$��15��$��15��$��0,0,0,0q�$ 0.5,0.5&���  �@ 
ItemsPanel �� .R��� $ Vertical=�.���  � RowDefinitions �� $
��auto ��� $��* �  ��%    .+�;   5System.Activities.Presentation.View.ExpressionTextBox  $��0,0,0,10q�   HintText$ Enter your text��$��0��	   ExpressionType"	 ��
   OwnerActivity
 �� *	ModelItem+   
Expression �� *ModelItem.argument+ �� Mode$ TwoWay=� �� 	Converter# [   �� ConverterParameter$ In��  $��0,0,0,10q�$��2��#��[  J� 	AllowDrop .    HintText$ Insert here��   Items ��  �� Path$ ModelItem.Activities�