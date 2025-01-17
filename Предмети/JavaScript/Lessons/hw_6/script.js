document.addEventListener('DOMContentLoaded', function() {
    const form = document.getElementById('colorForm');
    const palette = document.getElementById('palette');

    const savedColors = getColorsFromCookie();
    renderPalette(savedColors);

    form.addEventListener('submit', function(e) {
        e.preventDefault();

        const name = document.getElementById('name').value.trim();
        const type = document.getElementById('type').value;
        const code = document.getElementById('code').value.trim();

        if (!validateName(name)) {
            alert('Назва повинна містити лише літери');
            return;
        }

        if (!validateColorCode(type, code)) {
            alert('Невірний формат коду кольору');
            return;
        }

        if (savedColors.some(color => color.name.toLowerCase() === name.toLowerCase())) {
            alert('Назва кольору повинна бути унікальною');
            return;
        }

        const newColor = { name, type, code };
        savedColors.push(newColor);
        setColorsToCookie(savedColors);

        renderPalette(savedColors);
        form.reset();
    });

    function validateName(name) {
        return /^[a-zA-Zа-яА-ЯІі ]+$/.test(name);
    }

    function validateColorCode(type, code) {
        let isValid = false;
        if (type === 'RGB') {
            isValid = /^(\d{1,3}),\s?(\d{1,3}),\s?(\d{1,3})$/.test(code);
            if (isValid) {
                const parts = code.split(',').map(num => parseInt(num.trim()));
                isValid = parts.every(num => num >= 0 && num <= 255);
            }
        } else if (type === 'RGBA') {
            isValid = /^(\d{1,3}),\s?(\d{1,3}),\s?(\d{1,3}),\s?([01](?:\.\d+)?)$/.test(code);
            if (isValid) {
                const parts = code.split(',').map((num, index) => index === 3 ? parseFloat(num.trim()) : parseInt(num.trim()));
                isValid = parts.slice(0, 3).every(num => num >= 0 && num <= 255) && parts[3] >= 0 && parts[3] <= 1;
            }
        } else if (type === 'HEX') {
            isValid = /^#([A-Fa-f0-9]{6})$/.test(code);
        }
        return isValid;
    }

    function getColorsFromCookie() {
        const cookie = document.cookie.split('; ').find(row => row.startsWith('colors='));
        return cookie ? JSON.parse(decodeURIComponent(cookie.split('=')[1])) : [];
    }

    function setColorsToCookie(colors) {
        const cookieValue = encodeURIComponent(JSON.stringify(colors));
        const expires = new Date(Date.now() + 3 * 60 * 60 * 1000).toUTCString();
        document.cookie = `colors=${cookieValue}; expires=${expires}; path=/`;
    }

    function renderPalette(colors) {
        palette.innerHTML = '';
        colors.forEach(color => {
            const colorDiv = document.createElement('div');
            colorDiv.classList.add('color-item');
            colorDiv.style.backgroundColor = color.type === 'HEX' ? color.code : `rgba(${color.code})`;

            const colorInfo = document.createElement('div');
            colorInfo.classList.add('color-info');
            colorInfo.innerHTML = `<div>${color.name}</div><div>${color.type}</div><div>${color.code}</div>`;

            colorDiv.appendChild(colorInfo);
            palette.appendChild(colorDiv);
        });
    }
});
