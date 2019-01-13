using System;

namespace App.Application.EntitiesCommandsQueries.Utilities
{
    /// <summary>
	/// Used in conjunction with the .AsExpandable() extention, this will replace the extension method tagged
	/// with an expression defined by the linked Method.
	/// Usage: [ReplaceInExpressionTree(MethodName = nameof(YourExpression))]    
	/// </summary>
	public class ReplaceWithExpressionAttribute : Attribute
    {
        /// <summary>
        /// the name of the method returning an expression which you want to replace this extension with.
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// the name of the property returning an expression which you want to replace this extension with.
        /// </summary>
        public string PropertyName { get; set; }
    }
}
