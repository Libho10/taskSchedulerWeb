document.addEventListener("DOMContentLoaded", () => {
    const taskInput = document.getElementById("taskInput");
    const addBtn = document.getElementById("addBtn");
    const processBtn = document.getElementById("processBtn");
    const taskList = document.getElementById("taskList");
    const message = document.getElementById("message");

    // Function to load and display the current tasks
    async function loadTasks() {
        try {
            const response = await fetch('/api/task/list');
            const tasks = await response.json();

            if (tasks.length === 0) {
                taskList.innerHTML = "<i>No tasks in the queue.</i>";
            } else {
                taskList.innerHTML = "<ul>" + tasks.map(t => `<li>${t}</li>`).join('') + "</ul>";
            }
        } catch (error) {
            taskList.innerHTML = "<i>Error loading tasks.</i>";
        }
    }

    // Function to add a task by calling the backend POST /add
    async function addTask() {
        const task = taskInput.value.trim();
        if (!task) {
            message.textContent = "Please enter a task.";
            return;
        }

        try {
            const response = await fetch('/api/task/add', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ task })
            });
            const result = await response.json();
            message.textContent = result.message;
            taskInput.value = "";
            loadTasks();
        } catch (error) {
            message.textContent = "Failed to add task.";
        }
    }

    // Function to process the next task by calling POST /process
    async function processTask() {
        try {
            const response = await fetch('/api/task/process', { method: 'POST' });
            const result = await response.json();
            message.textContent = result.message;
            loadTasks();
        } catch (error) {
            message.textContent = "Failed to process task.";
        }
    }

    // Attach event listeners to buttons
    addBtn.addEventListener('click', addTask);
    processBtn.addEventListener('click', processTask);

    // Load tasks initially when page loads
    loadTasks();
});
