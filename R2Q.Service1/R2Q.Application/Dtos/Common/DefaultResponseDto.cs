namespace R2Q.Application.Dtos.Common
{
    /// <summary>
    /// Dto class for response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DefaultResponseDto<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultResponseDto{T}"/> class.
        /// </summary>
        public DefaultResponseDto()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultResponseDto{T}"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public DefaultResponseDto(T data)
        {
            Data = data;
        }

        /// <summary>
        /// Gets or sets the data.
        /// T can be of any data type
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public T Data { get; set; }
    }
}
