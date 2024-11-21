using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AppEmployee.Models;
using AppEmployee.DTOs;

namespace AppEmployee.Service
{
    public class EmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Ambil semua employee dari API
        public async Task<PaginatedResponse<ListEmployeeResponse>> GetEmployeesAsync(int pageNumber = 1, int pageSize = 10)
        {
            // URL dengan parameter pagination
            var response = await _httpClient.GetFromJsonAsync<BaseResponse<PaginatedResponse<ListEmployeeResponse>>>
                ($"api/employee?pageNumber={pageNumber}&pageSize={pageSize}");

            // Return seluruh bagian paginated response (items, totalData, currentPage, totalPages)
            return response?.Data ?? new PaginatedResponse<ListEmployeeResponse>();
        }

        public async Task<DetailEmployeeResponse> GetEmployeeByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<BaseResponse<DetailEmployeeResponse>>($"api/employee/{id}");
            return response?.Data ?? new DetailEmployeeResponse(); 
        }

        public async Task<EmployeeResponse?> CreateEmployeeAsync(EmployeeRequest employeeRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("api/employee", employeeRequest);
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error creating employee. Status: {response.StatusCode}, Content: {content}");
            }
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<EmployeeResponse>();
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/employee/{id}");
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response from delete: {content}");

            return response.IsSuccessStatusCode; 
        }


        public async Task<List<WorkUnit>> GetAllWorkUnitsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<BaseResponse<List<WorkUnit>>>("api/work-unit");
            return response?.Data?.ToList() ?? new List<WorkUnit>();
        }

        public async Task<List<EmploymentStatus>> GetAllEmploymentStatusesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<BaseResponse<List<EmploymentStatus>>>("api/employment-status");
            return response?.Data?.ToList() ?? new List<EmploymentStatus>();
        }

        public async Task<List<Position>> GetAllPositionsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<BaseResponse<List<Position>>>("api/position");
            return response?.Data?.ToList() ?? new List<Position>();
        }


    }
}
